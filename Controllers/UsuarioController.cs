using Agenda_Lieraria2._0.Repositorio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Agenda_Lieraria2._0.Repositorio.Usuario;
using Agenda_Lieraria2._0.Repositorio.Sessao;
using Agenda_Lieraria2._0.Models;

namespace Agenda_Lieraria2._0.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas ao usuário,
    /// como login, cadastro, alteração de cadastro e logout.
    /// </summary>
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _userRepo;
        private readonly ISessao _sessao;

        /// <summary>
        /// Construtor que recebe as dependências necessárias para a classe.
        /// </summary>
        /// <param name="userRepo">Repositório de usuários.</param>
        /// <param name="sessao">Serviço de sessão para gerenciar a autenticação.</param>
        public UsuarioController (IUsuarioRepositorio userRepo, ISessao sessao)
        {
            _userRepo = userRepo;
            _sessao = sessao;
        }

        #region Páginas

        /// <summary>
        /// Método responsável por exibir a página de login.
        /// Se o usuário já estiver autenticado, redireciona para a página principal.
        /// </summary>
        /// <returns>Retorna a View de login ou redireciona para a página principal.</returns>
        public IActionResult Login()
        {
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Main", "Main");
            return View();
        }

        /// <summary>
        /// Método responsável por exibir a página de cadastro de novo usuário.
        /// </summary>
        /// <returns>Retorna a View de cadastro.</returns>
        public IActionResult Cadastro()
        {
            return View();
        }

        /// <summary>
        /// Método responsável por exibir a página de alteração de cadastro do usuário.
        /// </summary>
        /// <returns>Retorna a View de alteração de cadastro.</returns>
        public IActionResult AlterarCadastro()
        {
            return View();
        }
        #endregion

        #region Formulário Cadastro 

        /// <summary>
        /// Método responsável por cadastrar um novo usuário no sistema.
        /// Realiza validações e cria uma sessão de usuário caso o cadastro seja bem-sucedido.
        /// </summary>
        /// <param name="model">Modelo com os dados do usuário para cadastro.</param>
        /// <returns>Redireciona para a página principal se o cadastro for bem-sucedido, 
        /// ou retorna a página de cadastro com uma mensagem de erro.</returns>
        [HttpPost]  
        public IActionResult Cadastrar(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool sucesso = _userRepo.CadastrarUsuario(model.Nome, model.Datanasc, model.NomeUsuario, model.Email, model.Senha);
                    if (sucesso)
                    {
                        var usuarioAutenticado = _userRepo.AutenticarUsuario(model.NomeUsuario, model.Senha);
                        if (usuarioAutenticado != null)
                        {
                            _sessao.CriarSessaoUsuario(usuarioAutenticado);
                            return RedirectToAction("Main", "Main");
                        }
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Algo deu errado. Tente novamente";
                    }
                }
                return RedirectToAction("Cadastro", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro na página. Tente novamente.";
                return RedirectToAction("Cadastro", "Usuario");
            }
        }
        #endregion

        #region Formulário Login

        /// <summary>
        /// Método responsável por autenticar um usuário no sistema.
        /// Valida os dados fornecidos e cria uma sessão de usuário se o login for bem-sucedido.
        /// </summary>
        /// <param name="model">Modelo com os dados de login (nome de usuário e senha).</param>
        /// <returns>Redireciona para a página principal se a autenticação for bem-sucedida, 
        /// ou retorna à página de login com uma mensagem de erro.</returns>
        [HttpPost]
        public IActionResult Entrar(UsuarioModel model)
        {
            try
            {
                ModelState.Remove("Nome");
                ModelState.Remove("Datanasc");
                ModelState.Remove("Email");
                if (ModelState.IsValid)
                {
                    var usuarioAutenticado = _userRepo.AutenticarUsuario(model.NomeUsuario, model.Senha);
                    if (usuarioAutenticado != null)
                    {
                        _sessao.CriarSessaoUsuario(usuarioAutenticado);
                        return RedirectToAction("Main", "Main");
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Tente novamente.";
                    }
                }
                return RedirectToAction("Login", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro na página. Tente novamente.";
                return RedirectToAction("Login", "Usuario");
            }
        }
        #endregion

        #region Formulário Alterar o Cadastro

        /// <summary>
        /// Método responsável por alterar os dados do cadastro do usuário.
        /// Atualiza o nome de usuário e o email, e cria uma nova sessão com os dados atualizados.
        /// </summary>
        /// <param name="model">Modelo com os dados alterados do usuário.</param>
        /// <returns>Redireciona para a página principal se a alteração for bem-sucedida, 
        /// ou retorna à página de alteração de cadastro com uma mensagem de erro.</returns>
        [HttpPost]
        public IActionResult AlterarCadastro(UsuarioModel model)
        {
            try
            {
                ModelState.Remove("Nome");
                ModelState.Remove("Datanasc");
                ModelState.Remove("Senha");
                if (ModelState.IsValid)
                {
                    bool alterado = _userRepo.AlterarCadastro(model.NomeUsuario, model.Email);
                    if (alterado)
                    {
                        var sessaoUsuario = _sessao.BuscarSessaoUsuario();
                        sessaoUsuario.NomeUsuario = model.NomeUsuario;
                        sessaoUsuario.Email = model.Email;
                        _sessao.CriarSessaoUsuario(sessaoUsuario); 
                        return RedirectToAction("Main", "Main");
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário e/ou email inválido(s). Tente novamente.";
                    }
                }
                return RedirectToAction("AlterarCadastro", "Usuario");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro na página. Tente novamente.";
                return RedirectToAction("AlterarCadastro", "Usuario");
            }
        }
        #endregion

        #region Logout

        /// <summary>
        /// Método responsável por finalizar a sessão do usuário e redirecionar para a página inicial.
        /// </summary>
        /// <returns>Redireciona para a página inicial após finalizar a sessão.</returns>
        public IActionResult Logout()
        {
            _sessao.FinalizarSessaoUsuario();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
