using Interfaces;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModelBuilder;

namespace Aveva.Controllers
{
    public class HomeController : Controller
    {
        private IViewModelBuilder _viewModelBuilder;
        private Item _homeItem;

        public HomeController()
        {
            _viewModelBuilder = new Builder();
            _homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath.ToString());
        }

        public ActionResult Header()
        {
            return View(_viewModelBuilder.BuildHeaderViewModel(_homeItem));
        }

        public ActionResult Menu()
        {
            return View(_viewModelBuilder.BuildMenuViewModel(_homeItem));
        }

        public ActionResult TopBody()
        {
            return View(_viewModelBuilder.BuildTopBodyViewModel(Sitecore.Context.Item));
        }

        public ActionResult LeftBody()
        {
            return View(_viewModelBuilder.BuildLeftBodyViewModel(Sitecore.Context.Item));
        }

        public ActionResult CenterBody()
        {
            return View(_viewModelBuilder.BuildCenterBodyViewModel(Sitecore.Context.Item));
        }

        public ActionResult RightBody()
        {
            return View(_viewModelBuilder.BuildRightBodyViewModel(Sitecore.Context.Item));
        }

        public ActionResult Footer()
        {
            return View(_viewModelBuilder.BuildFooterViewModel(_homeItem));
        }
    }
}