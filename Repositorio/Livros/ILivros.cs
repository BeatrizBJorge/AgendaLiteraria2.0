using Agenda_Lieraria2._0.Models;

namespace Agenda_Lieraria2._0.Repositorio.Livros
{
    public interface ILivros
    {
        List<LivrosModel> ObterTodos();
        List<LivrosModel> BuscarLivro(string nomeAcao);

        bool AdicionarJaLi(LivrosModel model, string nomeAcao);
        bool AdicionarEstouLendo(LivrosModel model, string nomeAcao);
        bool AdicionarQueroLer(LivrosModel model, string nomeAcao);

        List<LivrosModel> BuscarJaLi(int idUsuario);
        List<LivrosModel> BuscarEstouLendo(int idUsuario);
        List<LivrosModel> BuscarQueroLer(int idUsuario);

        bool DeletarJaLi(LivrosModel books, string nomeAcao);
        bool DeletarEstouLendo(LivrosModel books, string nomeAcao);
        bool DeletarQueroLer(LivrosModel books, string nomeAcao);
    }
}
