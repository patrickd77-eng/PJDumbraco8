using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace PJDu8.Controllers
{
    public class ContentController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER_PATH = "~/Views/Partials/Content/";

        public ActionResult RenderBodyText()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_MainBody.cshtml");
        }

    }
}