using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using PJDu8.Web.Models;
using Umbraco.Core.Models.PublishedContent;

namespace PJDu8.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER_PATH = "~/Views/Partials/SiteLayout/";

        public ActionResult RenderHeadHtml()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Head.cshtml");
        }
        /// <summary>
        /// Renders the top navigation in the header partial
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>

        public ActionResult RenderNavigation()
        {
            List<NavigationListItem> nav = GetNavigationModelFromDatabase();
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Header.cshtml", nav);
        }
        public ActionResult RenderFooter()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Footer.cshtml");
        }
        public ActionResult RenderCTA()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_CTA.cshtml");
        }
        private List<NavigationListItem> GetNavigationModelFromDatabase()
        {
            const int HOME_PAGE_POSITION_IN_PATH = 1;
            int homePageId = int.Parse(CurrentPage.Path.Split(',')[HOME_PAGE_POSITION_IN_PATH]);
            IPublishedContent homePage = Umbraco.Content(homePageId);
            List<NavigationListItem> nav = new List<NavigationListItem>();
            nav.Add(new NavigationListItem(new NavigationLink(homePage.Url, homePage.Name)));
            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItem> GetChildNavigationList(dynamic page)
        {
            List<NavigationListItem> listItems = null;
            var childPages = page.Children;
            if (childPages != null)
            {
                listItems = new List<NavigationListItem>();
                foreach (var childPage in childPages)
                {
                    NavigationListItem listItem = new NavigationListItem(new NavigationLink(childPage.Url, childPage.Name));
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }
    }
}