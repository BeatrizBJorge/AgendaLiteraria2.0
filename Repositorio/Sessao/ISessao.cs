using Agenda_Lieraria2._0.Models;

namespace Agenda_Lieraria2._0.Repositorio.Sessao
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void FinalizarSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
