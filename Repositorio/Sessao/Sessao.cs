using Agenda_Lieraria2._0.Models;
using Newtonsoft.Json;

namespace Agenda_Lieraria2._0.Repositorio.Sessao
{

    /// <summary>
    /// Classe responsável pela gestão da sessão do usuário, permitindo armazenar, recuperar e finalizar sessões.
    /// </summary>
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Construtor que inicializa a classe <see cref="Sessao"/> com um acessador de contexto HTTP.
        /// </summary>
        /// <param name="contextAccessor">Acessador de contexto HTTP utilizado para acessar informações da sessão.</param>
        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Recupera o objeto de usuário armazenado na sessão atual.
        /// </summary>
        /// <returns>
        /// Um objeto <see cref="UsuarioModel"/> representando o usuário da sessão, ou <c>null</c> caso não exista sessão ativa.
        /// </returns>
        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        /// <summary>
        /// Cria uma nova sessão para o usuário, armazenando seus dados na sessão.
        /// </summary>
        /// <param name="usuario">O objeto <see cref="UsuarioModel"/> contendo os dados do usuário a serem armazenados na sessão.</param>
        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        /// <summary>
        /// Finaliza a sessão do usuário, removendo seus dados da sessão.
        /// </summary>
        public void FinalizarSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
