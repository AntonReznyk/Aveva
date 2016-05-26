using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MenuViewModel
    {
        public string MenuName { get; set; }
        public string UrlPath { get; set; }
        public List<SubMenuItemViewModel> SubMenuItems { get; set; }

        public MenuViewModel()
        {
            SubMenuItems = new List<SubMenuItemViewModel>();
        }
    }
}
