﻿using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using PJDu8.Web.Models;
using Umbraco.Core.Models.PublishedContent;
using System.Runtime.Caching;
using System;
using Umbraco.Web;
using System.Linq;
using Umbraco.Core;

namespace PJDu8.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        const string PARTIAL_VIEW_FOLDER_PATH = "~/Views/Partials/SiteLayout/";

        public ActionResult RenderMetadata()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Metadata.cshtml");
        }
        /// <summary>
        /// Renders the top navigation in the header partial
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        public ActionResult RenderScripts()
        {
            return PartialView(PARTIAL_VIEW_FOLDER_PATH + "_Scripts.cshtml");
        }
        public ActionResult RenderNavigation()
        {
            List<NavigationListItem> nav = GetObjectFromCache<List<NavigationListItem>>("mainNav", 5, GetNavigationModelFromDatabase);
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
            IPublishedContent homePage = CurrentPage.AncestorOrSelf(1).DescendantOrSelf().AsEnumerableOfOne().FirstOrDefault(x => x.IsDocumentType("HomePage"));

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
        private List<NavigationListItem> GetChildNavigationList(IPublishedContent page)
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
        /// <summary>
        /// A generic function for getting and setting objects to the memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned.</typeparam>
        /// <param name="cacheItemName">The name to be used when storing this object in the cache.</param>
        /// <param name="cacheTimeInMinutes">How long to cache this object for.</param>
        /// <param name="objectSettingFunction">A parameterless function to call if the object isn't in the cache and you need to set it.</param>
        /// <returns>An object of the type you asked for</returns>
        private static T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<T> objectSettingFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = (T)cache[cacheItemName];
            if (cachedObject == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes);
                cachedObject = objectSettingFunction();
                cache.Set(cacheItemName, cachedObject, policy);
            }
            return cachedObject;
        }
    }
}