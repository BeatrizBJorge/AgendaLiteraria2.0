using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Agenda_Lieraria2._0.Models;

namespace Agenda_Lieraria2._0.Filters
{
    /// <summary>
    /// Filtro de ação que verifica se o usuário está logado antes de permitir o acesso a determinadas ações.
    /// </summary>
    public class UsuarioLogado : ActionFilterAttribute
    {
        /// <summary>
        /// Método sobrescrito da classe <see cref="ActionFilterAttribute"/> que é executado antes de uma ação ser chamada.
        /// Verifica se o usuário está logado na sessão. Caso contrário, redireciona o usuário para a página inicial.
        /// </summary>
        /// <param name="context">Contexto da execução da ação, contendo informações sobre a requisição e o estado da aplicação.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });

            }
            else
            {
                UsuarioModel login = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
                if (login == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
