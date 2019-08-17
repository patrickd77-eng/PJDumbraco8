using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace PJDu8.Controllers
{
    public class PortfolioController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER_PATH = "~/Views/Partials/Portfolio/";
        public ActionResult RenderTestimonials()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Testimonials.cshtml");
        }
    }
}