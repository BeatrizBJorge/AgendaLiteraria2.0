using Microsoft.AspNetCore.Mvc;
using Agenda_Lieraria2._0.Filters;
using Agenda_Lieraria2._0.Models;
using Agenda_Lieraria2._0.Repositorio;
using Agenda_Lieraria2._0.Repositorio.Sessao;
using Agenda_Lieraria2._0.Repositorio.Livros;
using Agenda_Lieraria2._0.Repositorio.Usuario;
using System.Reflection;

namespace Agenda_Lieraria2._0.Controllers
{
    [UsuarioLogado]
    public class LivrosController : Controller
    {
        private readonly ILivros _livros;
        private readonly ISessao _sessao;
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Construtor da classe que injeta as dependências necessárias.
        /// </summary>
        /// <param name="livros">Repositório de livros que será utilizado para acessar e manipular os dados dos livros.</param>
        /// <param name="sessao">Serviço responsável por gerenciar as sessões do usuário.</param>
        /// <param name="contextAccessor">Acessor do contexto HTTP, utilizado para obter informações da requisição.</param>
        public LivrosController(ILivros livros, ISessao sessao, IHttpContextAccessor contextAccessor)
        {
            _livros = livros;
            _sessao = sessao;
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Exibe o painel de controle do usuário, com as listas de livros que ele já leu, está lendo e quer ler.
        /// </summary>
        /// <returns>Retorna a view com o painel de controle (Dashboard) do usuário.</returns>
        public IActionResult Dashboard()
        {
            var sessaoUsuario = _sessao.BuscarSessaoUsuario();
            
            // Obtém as listas de livros do repositório
            var listaJaLi = _livros.BuscarJaLi(sessaoUsuario.IdUsuario);
            var listaEstouLendo = _livros.BuscarEstouLendo(sessaoUsuario.IdUsuario);
            var listaQueroLer = _livros.BuscarQueroLer(sessaoUsuario.IdUsuario);

            // Passa as listas para a view
            ViewBag.ListaJaLi = listaJaLi;
            ViewBag.ListaEstouLendo = listaEstouLendo;
            ViewBag.ListaQueroLer = listaQueroLer;

            return View();
        }

        # region Páginas dos livros
        public IActionResult ACasaNoMarCeruleo()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }
        public IActionResult AlemDaPortaSussurrante()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult APequenaLagarta()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult AViagemPlanetaHostil() 
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult CincoMulheres()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult Coraline()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult CriancasPeculiares()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult Eldest() 
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View(); 
        }

        public IActionResult EmAlgumLugarNasEstrelas()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult Eragon()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult GuerraQueSalvouMinhaVida()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult Hobbit()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult IlusaoDoTempo()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult JardimSecreto()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult LeveMeComVoce()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult MinhaVidaForaDosTrilhos()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult OAmanhaNaoEstaVenda()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult OCircoDaNoite()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult OMarSemEstrelas()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult OsDoisMorremNoFinal()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }
                             
        public IActionResult OsMiseraveis()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult Piranesi()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult PlantasMedicinais()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult PrimeiroAMorrerNoFinal()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult PsicologiaSocial()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult SempreFoiVoce()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult SenhorDosAneis_SociedadeAnel()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult SilencioDaCasaFria()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult SolTambemEUmaEstrela() 
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult TodaLuzQueNaoPodemosVer()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult ViagensDeGuilliver()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }

        public IActionResult VidaInvisivelAddieLaRue() 
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View(); 
        }

        public IActionResult Vilao()
        {
            var nomeAcao = ControllerContext.ActionDescriptor.ActionName;
            var livros = _livros.BuscarLivro(nomeAcao);
            ViewBag.NomeAcao = nomeAcao;
            return View();
        }
        #endregion


        /// <summary>
        /// Adiciona um livro a uma das listas do usuário (Já Li, Estou Lendo ou Quero Ler).
        /// </summary>
        /// <param name="model">Modelo de dados do livro a ser adicionado.</param>
        /// <param name="btn">Botão pressionado que indica qual lista o livro deve ser adicionado.</param>
        /// <returns>Redireciona para a página Dashboard ou exibe uma mensagem de erro.</returns>
        [HttpPost] 
        public IActionResult AdicionarLista(LivrosModel model, string btn, string nomeAcao)
        {
            var livro = _livros.BuscarLivro(nomeAcao).FirstOrDefault();
            if (livro == null)
            {
                TempData["MensagemErro"] = $"Livro não encontrado. Tente novamente.";
                return RedirectToAction("Dashboard", "Livros");
            }
            // Atualiza o modelo com os dados do livro buscado
            model.Id = livro.Id;
            model.Nome = livro.Nome;
            model.Autor = livro.Autor;
            model.Capa = livro.Capa;
            model.Filtro = livro.Filtro;
            model.Controller = livro.Controller;
            model.Action = livro.Action;

            bool sucesso = false;

            switch (btn)
            {
                case "jaLi":
                    sucesso = _livros.AdicionarJaLi(model, nomeAcao);
                    break;

                case "estouLendo":
                    sucesso = _livros.AdicionarEstouLendo(model, nomeAcao);
                    break;

                case "queroLer":
                    sucesso = _livros.AdicionarQueroLer(model, nomeAcao);
                    break;
            }

            if (sucesso)
            {
                TempData["MensagemSucesso"] = $"Livro adicionado com sucesso!";
                return RedirectToAction("Dashboard", "Livros"); 
            }
            else
            {
                TempData["MensagemErro"] = $"Houve um erro ao adicionar o Livro na Lista escolhida, tente novamente";
                return View(model); 
            }
        }


        /// <summary>
        /// Deleta um livro de uma das listas do usuário (Já Li, Estou Lendo ou Quero Ler).
        /// </summary>
        /// <param name="model">Modelo de dados do livro a ser adicionado.</param>
        /// <param name="btn">Botão pressionado que indica qual lista o livro deve ser deletado.</param>
        /// <returns>Redireciona para a página Dashboard ou exibe uma mensagem de erro.</returns>
        [HttpPost]
        public IActionResult DeletarDaLista(LivrosModel model, string btn)
        {
            // Divide o valor do botão em "ação" e "nomeAcao"
            var partes = btn.Split('-');
            if (partes.Length != 2)
            {
                TempData["MensagemErro"] = "Erro ao identificar o livro para exclusão.";
                return RedirectToAction("Dashboard", "Livros");
            }

            string acao = partes[0];
            string nomeAcao = partes[1];

            // Busca o livro pelo nome da ação
            var livro = _livros.BuscarLivro(nomeAcao).FirstOrDefault();
            if (livro == null)
            {
                TempData["MensagemErro"] = "Livro não encontrado. Tente novamente.";
                return RedirectToAction("Dashboard", "Livros");
            }

            // Atualiza o modelo com os dados do livro buscado
            model.Id = livro.Id;
            model.Nome = livro.Nome;
            model.Autor = livro.Autor;
            model.Capa = livro.Capa;
            model.Filtro = livro.Filtro;
            model.Controller = livro.Controller;
            model.Action = livro.Action;

            bool sucesso = false;

            switch (acao)
            {
                case "delJaLi":
                    sucesso = _livros.DeletarJaLi(model, nomeAcao);
                    break;

                case "delEstouLendo":
                    sucesso = _livros.DeletarEstouLendo(model, nomeAcao);
                    break;

                case "delQueroLer":
                    sucesso = _livros.DeletarQueroLer(model, nomeAcao);
                    break;
            }

            if (sucesso)
            {
                TempData["MensagemSucesso"] = "Livro excluído com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Houve um erro ao apagar o Livro na Lista escolhida, tente novamente!";
            }

            return RedirectToAction("Dashboard", "Livros");
        }

    }
}
