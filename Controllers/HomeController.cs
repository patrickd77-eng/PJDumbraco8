using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace PJDu8.Controllers
{
    public class HomeController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER_PATH = "~/Views/Partials/Home/";

        public ActionResult RenderBanner()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Banner.cshtml");
        }

        public ActionResult RenderHighlights()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Highlights.cshtml");
        }
        public ActionResult RenderCTA()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_CTA.cshtml");
        }


    }
}