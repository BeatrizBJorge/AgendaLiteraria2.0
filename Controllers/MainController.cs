using Agenda_Lieraria2._0.Models;
using Agenda_Lieraria2._0.Repositorio.Livros;
using Agenda_Lieraria2._0.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Agenda_Lieraria2._0.Controllers
{         
    [UsuarioLogado]
    public class MainController : Controller
    {
        private readonly ILivros _livro;

        /// <summary>
        /// Construtor da classe, recebe a dependência do repositório de livros.
        /// </summary>
        /// <param name="livroRepositorio">Instância do repositório de livros, responsável por fornecer dados sobre livros.</param>
        public MainController(ILivros livroRepositorio)
        {
            _livro = livroRepositorio;
        }

        /// <summary>
        /// Exibe a página principal com a lista de livros.
        /// Caso um termo de pesquisa seja informado, filtra os livros com base no nome, autor ou filtro.
        /// </summary>
        /// <param name="searchTerm">Termo de pesquisa para filtrar livros (opcional).</param>
        /// <returns>Retorna a view com a lista de livros filtrada, se o termo de pesquisa for fornecido.</returns>
        public IActionResult Main(string searchTerm = "")
        {
            var livros = _livro.ObterTodos();

            // Aplica o filtro caso um termo de pesquisa seja informado
            if (!string.IsNullOrEmpty(searchTerm))
            {
                livros = livros
                    .Where(l => l.Nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                l.Autor.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                l.Filtro.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            return View(livros);
            //return View(livros ?? new List<LivrosModel>()); // Garante que nunca será nulo
        }

        /// <summary>
        /// Exibe a página 'Sobre Nós', fornecendo informações sobre o sistema ou organização.
        /// </summary>
        /// <returns>Retorna a view 'SobreNos'.</returns>
        public IActionResult SobreNos()
        {
            return View();
        }

        /// <summary>
        /// Exibe a página da biblioteca, provavelmente para exibir uma lista de livros ou recursos.
        /// </summary>
        /// <returns>Retorna a view 'Biblioteca'.</returns>
        public IActionResult Biblioteca()
        {
            return View();
        }
    }
}
