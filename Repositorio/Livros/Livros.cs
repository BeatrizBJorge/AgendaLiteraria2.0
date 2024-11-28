using System;
using System.Data;
using System.Reflection;
using System.Text.Json;
using Agenda_Lieraria2._0.Models;
using Agenda_Lieraria2._0.Repositorio.Sessao;
using Microsoft.Data.SqlClient;

namespace Agenda_Lieraria2._0.Repositorio.Livros
{
    public class Livros : ILivros
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISessao _sessao;
        private readonly DAL _dal = new DAL();

        public Livros(IConfiguration configuration, IHttpContextAccessor contextAccessor, ISessao sessao)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("db_agendalit");
            _contextAccessor = contextAccessor;
            _sessao = sessao;
        }

        /// <summary>
        /// Método que busca todos os livros cadastrados.
        /// Realiza uma consulta no arquivo JSON, e traz todas as informações presentes.
        /// </summary>
        /// <returns>Uma lista de objetos LivrosModel com todos os livros. 
        /// Retorna a lista vazia em caso de erro ou exceção.</returns>
        public List<LivrosModel> ObterTodos()
        {
            string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Livros.json");
            string json = System.IO.File.ReadAllText(caminhoArquivo);
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var livros = JsonSerializer.Deserialize<List<LivrosModel>>(json, options);
            return livros ?? new List<LivrosModel>(); // Retorna uma lista vazia se livros for null
        }

        /// <summary>
        /// Método que verifica se o livro existe no banco de dados.
        /// Realiza uma consulta na tabela 'livros' para encontrar os livros 
        /// de acordo com o nome da action.
        /// </summary>
        /// <param name="nomeAcao">Nome da view para buscar o livro.</param>
        public List<LivrosModel> BuscarLivro(string nomeAcao)
        {
            List<LivrosModel>? listaPesquisa = new List<LivrosModel>();

            string query = $"SELECT * FROM livros WHERE action = '{nomeAcao}'";
            _dal.stringConexao = _connectionString;

            DataTable dTable = new DataTable();
            try
            {
                dTable = _dal.buscaDataTable(query);

                foreach (DataRow dr in dTable.Rows)
                {
                    LivrosModel livros = new LivrosModel();

                    livros.Id = Convert.ToInt32(dr["idLivro"]);   
                    livros.Nome = dr["nome"].ToString();
                    livros.Autor = dr["autor"].ToString();
                    livros.Capa = dr["capa"].ToString();
                    livros.Filtro = dr["filtro"].ToString();
                    livros.Controller = dr["controller"].ToString();
                    livros.Action = dr["action"].ToString();

                    listaPesquisa.Add(livros);
                }

            }
            catch (SqlException)
            {
                listaPesquisa = null;
            }
            finally
            {
                dTable = null;
            }

            return listaPesquisa;
        }

        #region Dashboard
        /// <summary>
        /// Método que busca os livros que o usuário já leu. 
        /// Realiza uma consulta na tabela 'lista_usuario' e 'livros' para encontrar os livros 
        /// associados ao usuário com status 'já lidos' (idLista = 1).
        /// </summary>
        /// <param name="idUsuario">ID do usuário para identificar a sessão e buscar os livros.</param>
        /// <returns>Uma lista de objetos LivrosModel com os livros que o usuário já leu. 
        /// Retorna null em caso de erro ou exceção.</returns>
        public List<LivrosModel> BuscarJaLi (int idUsuario)
        {
            List<LivrosModel>? listaPesquisa = new List<LivrosModel> ();
            var sessaoUsuario = _sessao.BuscarSessaoUsuario();

            _dal.stringConexao = _connectionString;
            DataTable dTable = new DataTable();

            string query = $@"SELECT livros.nome, livros.autor, livros.capa, livros.action 
                            FROM lista_usuario
                            JOIN livros ON lista_usuario.idLivro = livros.idLivro
                            WHERE lista_usuario.idLista = 1 AND lista_usuario.idUsuario = {sessaoUsuario.IdUsuario}";

            try
            {
                dTable = _dal.buscaDataTable(query);

                foreach (DataRow dr in dTable.Rows)
                {
                    LivrosModel livros = new LivrosModel();
                    livros.Nome = dr["nome"].ToString();
                    livros.Autor = dr["autor"].ToString();
                    livros.Capa = dr["capa"].ToString();
                    livros.Action = dr["action"].ToString();

                    listaPesquisa.Add(livros);
                }

            }
            catch (SqlException)
            {
                listaPesquisa = null;
            }
            finally
            {
                dTable = null;
            }
            return listaPesquisa;
        }

        /// <summary>
        /// Método que busca os livros que o usuário está lendo atualmente.
        /// Realiza uma consulta na tabela 'lista_usuario' e 'livros' para encontrar os livros 
        /// associados ao usuário com status 'estou lendo' (idLista = 2).
        /// </summary>
        /// <param name="idUsuario">ID do usuário para identificar a sessão e buscar os livros.</param>
        /// <returns>Uma lista de objetos LivrosModel com os livros que o usuário está lendo. 
        /// Retorna null em caso de erro ou exceção.</returns>
        public List<LivrosModel> BuscarEstouLendo(int idUsuario)
        {
            List<LivrosModel>? listaPesquisa = new List<LivrosModel>();
            var sessaoUsuario = _sessao.BuscarSessaoUsuario();

            _dal.stringConexao = _connectionString;
            DataTable dTable = new DataTable();

            string query = $@"SELECT livros.nome, livros.autor, livros.capa, livros.action 
                            FROM lista_usuario
                            JOIN livros ON lista_usuario.idLivro = livros.idLivro
                            WHERE lista_usuario.idLista = 2 AND lista_usuario.idUsuario = {sessaoUsuario.IdUsuario}";

            try
            {
                dTable = _dal.buscaDataTable(query);

                foreach (DataRow dr in dTable.Rows)
                {
                    LivrosModel livros = new LivrosModel();
                    livros.Nome = dr["nome"].ToString();
                    livros.Autor = dr["autor"].ToString();
                    livros.Capa = dr["capa"].ToString();
                    livros.Action = dr["action"].ToString();

                    listaPesquisa.Add(livros);
                }

            }
            catch (SqlException)
            {
                listaPesquisa = null;
            }
            finally
            {
                dTable = null;
            }
            return listaPesquisa;
        }

        /// <summary>
        /// Método que busca os livros que o usuário deseja ler.
        /// Realiza uma consulta na tabela 'lista_usuario' e 'livros' para encontrar os livros 
        /// associados ao usuário com status 'quero ler' (idLista = 3).
        /// </summary>
        /// <param name="idUsuario">ID do usuário para identificar a sessão e buscar os livros.</param>
        /// <returns>Uma lista de objetos LivrosModel com os livros que o usuário deseja ler. 
        /// Retorna null em caso de erro ou exceção.</returns>
        public List<LivrosModel> BuscarQueroLer(int idUsuario)
        {
            List<LivrosModel>? listaPesquisa = new List<LivrosModel>();
            var sessaoUsuario = _sessao.BuscarSessaoUsuario();

            _dal.stringConexao = _connectionString;
            DataTable dTable = new DataTable();

            string query = $@"SELECT livros.nome, livros.autor, livros.capa, livros.action 
                            FROM lista_usuario
                            JOIN livros ON lista_usuario.idLivro = livros.idLivro
                            WHERE lista_usuario.idLista = 3 AND lista_usuario.idUsuario = {sessaoUsuario.IdUsuario}";

            try
            {
                dTable = _dal.buscaDataTable(query);

                foreach (DataRow dr in dTable.Rows)
                {
                    LivrosModel livros = new LivrosModel();
                    livros.Nome = dr["nome"].ToString();
                    livros.Autor = dr["autor"].ToString();
                    livros.Capa = dr["capa"].ToString();
                    livros.Action = dr["action"].ToString();

                    listaPesquisa.Add(livros);
                }

            }
            catch (SqlException)
            {
                listaPesquisa = null;
            }
            finally
            {
                dTable = null;
            }
            return listaPesquisa;
        }

        #endregion

        #region Adicionar nas Listas

        /// <summary>
        /// Adiciona um livro à lista "Já Li" do usuário.
        /// </summary>
        /// <param name="model">Modelo do livro com informações adicionais.</param>
        /// <param name="nomeAcao">Nome da ação a ser realizada, utilizado para identificar o livro.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida, caso contrário <c>false</c>.</returns>
        public bool AdicionarJaLi(LivrosModel model, string nomeAcao)
        {
            bool executado = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            _dal.stringConexao = _connectionString;

            var livros = BuscarLivro(nomeAcao);

            if (livros != null && livros.Any() && sessaoUsuario?.IdUsuario > 0)
            {
                var livro = livros.First(); 
                string query = $@"INSERT INTO lista_usuario(idUsuario, idLivro, idLista) 
                                  VALUES ({sessaoUsuario.IdUsuario}, {livro.Id}, 1)";
                try
                {
                    executado = _dal.ExecuteSql(query);
                }
                catch { }
            }
            return executado;
        }

        /// <summary>
        /// Adiciona um livro à lista "Estou Lendo" do usuário.
        /// </summary>
        /// <param name="model">Modelo do livro com informações adicionais.</param>
        /// <param name="nomeAcao">Nome da ação a ser realizada, utilizado para identificar o livro.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida, caso contrário <c>false</c>.</returns>
        public bool AdicionarEstouLendo(LivrosModel model, string nomeAcao)
        {
            bool executado = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            _dal.stringConexao = _connectionString;

            var livros = BuscarLivro(nomeAcao);

            if (livros != null && livros.Any() && sessaoUsuario?.IdUsuario > 0)
            {
                var livro = livros.First();
                string query = $@"INSERT INTO lista_usuario(idUsuario, idLivro, idLista) 
                                  VALUES ({sessaoUsuario.IdUsuario}, {livro.Id}, 2)";
                try
                {
                    executado = _dal.ExecuteSql(query);
                }
                catch { }
            }
            return executado;
        }

        /// <summary>
        /// Adiciona um livro à lista "Quero Ler" do usuário.
        /// </summary>
        /// <param name="model">Modelo do livro com informações adicionais.</param>
        /// <param name="nomeAcao">Nome da ação a ser realizada, utilizado para identificar o livro.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida, caso contrário <c>false</c>.</returns>
        public bool AdicionarQueroLer(LivrosModel model, string nomeAcao)
        {
            bool executado = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            _dal.stringConexao = _connectionString;

            var livros = BuscarLivro(nomeAcao);

            if (livros != null && livros.Any() && sessaoUsuario?.IdUsuario > 0)
            {
                var livro = livros.First();
                string query = $@"INSERT INTO lista_usuario(idUsuario, idLivro, idLista) 
                                  VALUES ({sessaoUsuario.IdUsuario}, {livro.Id}, 3)";
                try
                { 
                    executado = _dal.ExecuteSql(query);
                }
                catch { }
            }
            return executado;
        }
        #endregion

        #region Deletar Livro da Lista

        /// <summary>
        /// Remove um livro da lista "Já Li" do usuário.
        /// </summary>
        /// <param name="books">Modelo do livro que será removido.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida, caso contrário <c>false</c>.</returns>
        public bool DeletarJaLi(LivrosModel books, string nomeAcao)
        {
            bool deletar = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            _dal.stringConexao = _connectionString;

            var livro = BuscarLivro(books.Action);

            if (livro != null && livro.Any() && sessaoUsuario?.IdUsuario > 0)
            {
                var livros = livro.First();
                string query = $@"DELETE FROM lista_usuario WHERE idUsuario = {sessaoUsuario.IdUsuario} AND idLivro = {livros.Id} AND idLista = 1";
                try
                {
                    deletar = _dal.ExecuteSql(query);
                }
                catch { }
            }

            return deletar;
        }

        /// <summary>
        /// Remove um livro da lista "Estou Lendo" do usuário.
        /// </summary>
        /// <param name="books">Modelo do livro que será removido.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida, caso contrário <c>false</c>.</returns>
        public bool DeletarEstouLendo(LivrosModel books, string nomeAcao)
        {
            bool deletar = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            _dal.stringConexao = _connectionString;

            var livro = BuscarLivro(books.Action);

            if (livro != null && livro.Any() && sessaoUsuario?.IdUsuario > 0)
            {
                var livros = livro.First();
                string query = $@"DELETE FROM lista_usuario WHERE idUsuario = {sessaoUsuario.IdUsuario} AND idLivro = {livros.Id} AND idLista = 2";
                try
                {
                    deletar = _dal.ExecuteSql(query);
                }
                catch { }
            }

            return deletar;
        }

        /// <summary>
        /// Remove um livro da lista "Quero Ler" do usuário.
        /// </summary>
        /// <param name="books">Modelo do livro que será removido.</param>
        /// <returns>Retorna <c>true</c> se a operação for bem-sucedida, caso contrário <c>false</c>.</returns>
        public bool DeletarQueroLer(LivrosModel books, string nomeAcao)
        {
            bool deletar = false;

            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            _dal.stringConexao = _connectionString;

            var livro = BuscarLivro(books.Action);

            if (livro != null && livro.Any() && sessaoUsuario?.IdUsuario > 0)
            {
                var livros = livro.First();
                string query = $@"DELETE FROM lista_usuario WHERE idUsuario = {sessaoUsuario.IdUsuario} AND idLivro = {livros.Id} AND idLista = 3";
                try
                {
                    deletar = _dal.ExecuteSql(query);
                }
                catch { }
            }

            return deletar;
        }

        #endregion

    }
}
