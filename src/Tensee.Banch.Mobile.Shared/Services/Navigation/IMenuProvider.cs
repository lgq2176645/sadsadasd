using System.Collections.Generic;
using MvvmHelpers;
using Tensee.Banch.Models.NavigationMenu;

namespace Tensee.Banch.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}