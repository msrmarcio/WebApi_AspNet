using Impacta.MOD;
using System.Web.Mvc;
using System.Web.Security;

/*
 * ESTA CLASSE REALIZARÁ AUTENTICAÇÃO UTILIZANDO 
 * AUTHORIZATION / AUTHENTICATION / FILTERS
 * */
namespace Impacta.Tarefas.Controllers
{
	public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Autenticacao()
        {
			Usuario usuario = null;
			
			return View(usuario);

			// ja criar a view
        }

		[HttpPost]
		public ActionResult AutenticarLogin(Usuario usuario)
		{
			//segundo parametro é relativo ao COOKIE,
			//é para persistir o usuario, caso seja true,
			//ele sempre irá considerar que usuário já esta autenticado
			FormsAuthentication.SetAuthCookie(usuario.Username, false);
			return RedirectToAction("Index", "RealBooks");
		}

		public ActionResult Logout()
		{
			//Remove o FormsAuthentication do Browser;
			FormsAuthentication.SignOut();
			// retorna para a View de Login
			return View("Autenticacao");
		}
	}
}