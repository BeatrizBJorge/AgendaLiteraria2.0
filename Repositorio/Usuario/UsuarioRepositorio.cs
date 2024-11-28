using Agenda_Lieraria2._0.Models;
using Agenda_Lieraria2._0.Repositorio.Sessao;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Agenda_Lieraria2._0.Repositorio.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISessao _sessao;

        /// <summary>
        /// Construtor da classe, recebe as dependências necessárias para acessar a configuração,
        /// contexto HTTP e a sessão do usuário.
        /// </summary>
        /// <param name="configuration">Interface de configuração para acessar as strings de conexão.</param>
        /// <param name="contextAccessor">Acessor do contexto HTTP para obter informações da sessão.</param>
        /// <param name="sessao">Interface de sessão para gerenciar a sessão de usuário.</param>
        public UsuarioRepositorio(IConfiguration configuration, IHttpContextAccessor contextAccessor, ISessao sessao)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("db_agendalit");
            _contextAccessor = contextAccessor;
            _sessao = sessao;
        }

        private readonly DAL _dal = new DAL();

        #region Cadastro de Usuário

        /// <summary>
        /// Realiza o cadastro de um novo usuário no sistema.
        /// Recebe as informações do usuário e as insere no banco de dados.
        /// </summary>
        /// <param name="nome">Nome completo do usuário.</param>
        /// <param name="dataNasc">Data de nascimento do usuário.</param>
        /// <param name="nomeUsuario">Nome de usuário escolhido.</param>
        /// <param name="email">Endereço de email do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <returns>Retorna um valor booleano indicando se a operação foi bem-sucedida.</returns>
        public bool CadastrarUsuario(string nome, DateTime dataNasc, string nomeUsuario, string email, string senha)
        {
            bool executado = false;
            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
           
            _dal.stringConexao = _connectionString;
            DataTable dTable = new DataTable();

            string query = $@"INSERT INTO usuarios (nome, datanasc, nomeUsuario, email, senha) VALUES ('{nome}', '{dataNasc:yyyy-MM-dd}', '{nomeUsuario}', '{email}', '{senha}')";
            try
            {
                executado = _dal.ExecuteSql(query);
            }
            catch
            {
            }

            return executado;
        }
        #endregion

        #region Login 

        /// <summary>
        /// Autentica o usuário no sistema, verificando se o nome de usuário e a senha são válidos.
        /// </summary>
        /// <param name="nomeUsuario">Nome de usuário fornecido pelo usuário.</param>
        /// <param name="senha">Senha fornecida pelo usuário.</param>
        /// <returns>Retorna um objeto UsuarioModel com os dados do usuário autenticado, ou null se falhar.</returns>
        public UsuarioModel AutenticarUsuario(string nomeUsuario, string senha)
        {
            _dal.stringConexao = _connectionString;
            DataTable dTable = new DataTable();

            string query = $@"SELECT * FROM usuarios WHERE nomeUsuario = '{nomeUsuario}' AND senha = '{senha}'";

            try
            {
                dTable = _dal.buscaDataTable(query);
                if (dTable.Rows.Count > 0)
                {
                    // Cria o objeto UsuarioModel com os dados do usuário autenticado
                    var usuario = new UsuarioModel
                    {
                        IdUsuario = Convert.ToInt32(dTable.Rows[0]["idUsuario"]),
                        Nome = dTable.Rows[0]["nome"].ToString(),
                        NomeUsuario = dTable.Rows[0]["nomeUsuario"].ToString(),
                        Email = dTable.Rows[0]["email"].ToString(),
                        Senha = dTable.Rows[0]["senha"].ToString()
                    };

                    return usuario; // Retorna o usuário autenticado
                }
            }
            catch{ }

            return null; 
        }
        #endregion

        #region Alterar cadastro

        /// <summary>
        /// Atualiza o cadastro do usuário, permitindo modificar o nome de usuário e o email.
        /// </summary>
        /// <param name="nomeUsuario">Novo nome de usuário.</param>
        /// <param name="email">Novo email.</param>
        /// <returns>Retorna true se a atualização foi bem-sucedida, caso contrário, retorna false.</returns>
        public bool AlterarCadastro(string nomeUsuario, string email)
        {
            bool executado = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            if (sessaoUsuario == null) return false;

            _dal.stringConexao = _connectionString;
            DataTable dTable = new DataTable();
             

            string query = $@"UPDATE usuarios SET nomeUsuario = '{nomeUsuario}', email = '{email}' WHERE idUsuario = '{sessaoUsuario.IdUsuario}' ";

            try
            {
                executado = _dal.ExecuteSql(query);
            }
            catch
            { 
            }

            return executado;
        }
        #endregion

        #region Exemplo sem sql injection

        //public bool CadastrarUsuario(string nome, DateTime dataNasc, string nomeUsuario, string email, string senha)
        //{
        //    bool executado = false;

        //    var sessaoUsuario = _sessao.BuscarSessaoUsuario();

        //    string query = @"INSERT INTO usuarios (nome, datanasc, nomeUsuario, email, senha) 
        //             VALUES (@Nome, @DataNasc, @NomeUsuario, @Email, @Senha)";

        //    try
        //    {
        //        using (var connection = new SqlConnection(_connectionString))
        //        using (var command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Nome", nome);
        //            command.Parameters.AddWithValue("@DataNasc", dataNasc);
        //            command.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);
        //            command.Parameters.AddWithValue("@Email", email);
        //            command.Parameters.AddWithValue("@Senha", senha);

        //            connection.Open();
        //            executado = command.ExecuteNonQuery() > 0; // Retorna true se a execução afetou linhas
        //        }
        //    }
        //    catch
        //    {
        //    }

        //    return executado;
        //}

        //public bool AutenticarUsuario(string nomeUsuario, string senha)
        //{
        //    bool sucesso = false;

        //    string query = @"SELECT * FROM usuarios WHERE nomeUsuario = @NomeUsuario AND senha = @Senha";

        //    DataTable dTable = new DataTable();
        //    try
        //    {
        //        using (var connection = new SqlConnection(_connectionString))
        //        using (var command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);
        //            command.Parameters.AddWithValue("@Senha", senha);

        //            connection.Open();
        //            using (var reader = command.ExecuteReader())
        //            {
        //                sucesso = reader.HasRows; // Verifica se há resultados
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }

        //    return sucesso;
        //}
        //public bool AlterarCadastro(string nomeUsuario, string email)
        //{
        //    bool executado = false;

        //    var sessaoUsuario = _sessao.BuscarSessaoUsuario();

        //    string query = @"UPDATE usuarios SET nomeUsuario = @NomeUsuario, email = @Email WHERE nomeUsuario = @NomeUsuario"; // Adicione a condição WHERE para evitar atualizar todos os registros.

        //    try
        //    {
        //        using (var connection = new SqlConnection(_connectionString))
        //        using (var command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@NomeUsuario", nomeUsuario);
        //            command.Parameters.AddWithValue("@Email", email);

        //            connection.Open();
        //            executado = command.ExecuteNonQuery() > 0; // Retorna true se a execução afetou linhas
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return executado;
        //}
        #endregion
    }
}
