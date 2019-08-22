﻿using System.Web.Mvc;
using Umbraco.Web.Mvc;
using PJDu8.Models;
using System.Net.Mail;
using System.Reflection;

namespace PJDu8.Controllers

{
    public class ContactController : SurfaceController
    {

        public string GetViewPath(string name)
        {
            return $"/Views/Partials/Contact/{name}.cshtml";
        }
        [HttpGet]
        public ActionResult RenderForm()
        {

            return PartialView(GetViewPath("_ContactForm"), new ContactViewModel());
        }
        [HttpPost]
        public ActionResult RenderForm(ContactViewModel model)
        {
            return PartialView(GetViewPath("_ContactForm"), model);
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
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();

                string toAddress = System.Web.Configuration.WebConfigurationManager.AppSettings["ContactEmailTo"];
                string fromAddress = System.Web.Configuration.WebConfigurationManager.AppSettings["ContactEmailFrom"];

                message.Subject = $"You have a new enquiry from: {model.Name} - and their email is: {model.Email}";
                message.Body = $"{model.Message}";
                message.To.Add(new MailAddress(toAddress, toAddress));
                message.From = (new MailAddress(fromAddress, fromAddress));

                client.Send(message);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}