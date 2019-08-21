using System.Web.Mvc;
using Umbraco.Web.Mvc;
using PJDu8.Models;
using System.Net.Mail;
namespace PJDu8.Controllers
{
    public class ContactController : SurfaceController
    {
       
        public string GetViewPath(string name)
        {
            return $"~/Views/Partials/Contact/{name}.cshtml";
        }
        [HttpGet]
        public ActionResult RenderForm()
        {

            return PartialView(GetViewPath("_ContactForm"), new ContactViewModel());
        }
        [HttpPost]
        public ActionResult RenderForm(ContactViewModel model)
        {
            return PartialView(GetViewPath("ContactForm"), model);
        }
        [HttpPost]
        public ActionResult SubmitForm(ContactViewModel model)
        {
            bool success = false;
             if (ModelState.IsValid)
            {
                success = SendEmail(model);
            }
            return PartialView(GetViewPath(success ? "_Success" : "_Error"));
        }
        public bool SendEmail(ContactViewModel model)
        {
            //code for send email
            return true;
            // https://youtu.be/g3pVRW5nF4U?list=PL90L_HquhD-_Wu55PJ9N8mZ6Lh5Rhy0X6&t=1318
        }
    }
}