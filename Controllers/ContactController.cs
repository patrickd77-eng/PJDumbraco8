using System.Web.Mvc;
using Umbraco.Web.Mvc;
using PJDu8.Models;

namespace PJDu8.Controllers
{
    public class ContactController : SurfaceController
    {
       
        public string GetViewPath(string name)
        {
            return $"~/Views/Partials/Contact/{name}.cshtml";
        }
        public ActionResult RenderForm()
        {

            return PartialView(GetViewPath("_ContactForm"), new ContactViewModel());
        }
    }
}