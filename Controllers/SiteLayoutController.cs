using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace PJDu8.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER_PATH = "~/Views/Partials/SiteLayout/";

        public ActionResult RenderHeadHtml()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Head.cshtml");
        }
        public ActionResult RenderNavigation()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Header.cshtml");
        }
        public ActionResult RenderFooter()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Footer.cshtml");
        }
      


    }
}