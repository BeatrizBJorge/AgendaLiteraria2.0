using Agenda_Lieraria2._0.Repositorio.Livros;
using Newtonsoft.Json;

namespace Agenda_Lieraria2._0.Models
{
    /// <summary>
    /// Representa um livro na plataforma de agenda literária.
    /// </summary>
    public class LivrosModel
    {
        /// <summary>
        /// Identificador único do livro.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do livro.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Nome do Autor do livro.
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Caminho para a imagem da capa do livro.
        /// </summary>
        public string Capa { get; set; }
        /// <summary>
        /// Filtro para saber se o livro é gratuito.
        /// </summary>
        public string Filtro { get; set; }
        /// <summary>
        /// Nome do controlador do livro.
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Nome da ação do livro.
        /// </summary>
        public string Action { get; set; }
        
    }
}
