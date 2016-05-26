using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Interfaces
{
    public interface IViewModelBuilder
    {
        HeaderViewModel BuildHeaderViewModel(Item mainItem);
        IEnumerable<MenuViewModel> BuildMenuViewModel(Item mainItem);
        TopBodyViewModel BuildTopBodyViewModel(Item mainItem);
        LeftBodyViewModel BuildLeftBodyViewModel(Item mainItem);
        CenterBodyViewModel BuildCenterBodyViewModel(Item mainItem);
        RightBodyViewModel BuildRightBodyViewModel(Item mainItem);
    }
}
