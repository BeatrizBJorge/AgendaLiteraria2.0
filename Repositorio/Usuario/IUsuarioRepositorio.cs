using Agenda_Lieraria2._0.Models;

namespace Agenda_Lieraria2._0.Repositorio.Usuario
{
    public interface IUsuarioRepositorio
    {
        bool CadastrarUsuario(string nome, DateTime datanasc, string nomeUsuario, string email, string senha);
        UsuarioModel AutenticarUsuario(string nomeUsuario, string senha);
        bool AlterarCadastro(string nomeUsuario, string email);
    }
}