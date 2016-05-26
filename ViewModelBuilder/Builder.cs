using Interfaces;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ViewModelBuilder
{
    public class Builder : IViewModelBuilder
    {
        public HeaderViewModel BuildHeaderViewModel(Item mainItem)
        {
            HeaderViewModel headerViewModel = new HeaderViewModel();

            var childList = mainItem.GetChildren();
            var headerItem = childList.FirstOrDefault(x => x.TemplateName == "Header");

            string url = string.Empty;
            ImageField imageField = headerItem.Fields["Logo"];
            if (imageField != null && imageField.MediaItem != null)
            {
                MediaItem media = new MediaItem(imageField.MediaItem);
                url = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(media));
            }

            headerViewModel.Name = headerItem.Fields["Name"].Value;
            headerViewModel.URLLogo = url;

            return headerViewModel;
        }

        public IEnumerable<MenuViewModel> BuildMenuViewModel(Item mainItem)
        {
            List<MenuViewModel> menuViewModelList = new List<MenuViewModel>();

            var childList = mainItem.GetChildren();
            var headerItem = childList.FirstOrDefault(x => x.TemplateName == "Header");

            var headerChildList = headerItem.GetChildren();
            var menuItemList = headerChildList.Where(x => x.TemplateName == "Menu");

            foreach (var item in menuItemList)
            {
                MenuViewModel menuViewModel = new MenuViewModel();

                menuViewModel.MenuName = item.Fields["Menu name"].Value;
                menuViewModel.UrlPath = item.Fields["Link"].Value;

                var subMenuList = item.GetChildren().Where(x => x.TemplateName == "Sub menu");
                foreach (var subMenuItem in subMenuList)
                {
                    SubMenuItemViewModel subMenuItemViewModel = new SubMenuItemViewModel();

                    subMenuItemViewModel.Name = subMenuItem.Fields["Menu name"].Value;
                    subMenuItemViewModel.UrlPath = subMenuItem.Fields["Link"].Value;

                    menuViewModel.SubMenuItems.Add(subMenuItemViewModel);
                }

                menuViewModelList.Add(menuViewModel);
            }

            return menuViewModelList;
        }

        public TopBodyViewModel BuildTopBodyViewModel(Item currentItem)
        {
            TopBodyViewModel topBodyViewModel = new TopBodyViewModel();
            var childList = currentItem.GetChildren();
            var bodyItem = childList.FirstOrDefault(x => x.Name == "TopBody");
            topBodyViewModel.Text = bodyItem.Fields["Content"].Value;

            return topBodyViewModel;
        }

        public LeftBodyViewModel BuildLeftBodyViewModel(Item currentItem)
        {
            LeftBodyViewModel leftBodyViewModel = new LeftBodyViewModel();
            var childList = currentItem.GetChildren();
            var bodyItem = childList.FirstOrDefault(x => x.Name == "LeftBody");
            leftBodyViewModel.Text = bodyItem.Fields["Content"].Value;

            return leftBodyViewModel;
        }

        public CenterBodyViewModel BuildCenterBodyViewModel(Item currentItem)
        {
            CenterBodyViewModel centerBodyViewModel = new CenterBodyViewModel();
            var childList = currentItem.GetChildren();
            var bodyItem = childList.FirstOrDefault(x => x.Name == "CenterBody");
            centerBodyViewModel.Text = bodyItem.Fields["Content"].Value;

            return centerBodyViewModel;
        }

        public RightBodyViewModel BuildRightBodyViewModel(Item currentItem)
        {
            RightBodyViewModel rightBodyViewModel = new RightBodyViewModel();
            var childList = currentItem.GetChildren();
            var bodyItem = childList.FirstOrDefault(x => x.Name == "RightBody");
            rightBodyViewModel.Text = bodyItem.Fields["Content"].Value;

            return rightBodyViewModel;
        }

        public FooterViewModel BuildFooterViewModel(Item mainItem)
        {
            FooterViewModel footer = new FooterViewModel();
            footer.Text = mainItem.GetChildren().FirstOrDefault(x => x.Name == "Footer").Fields["Content"].Value;

            return footer;
        }
    }
}
