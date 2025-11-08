using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Samba.Localization.Properties;
using Samba.Modules.FastPayModule;
using Samba.Presentation.Common;
using Samba.Presentation.Services;
using Samba.Presentation.Services.Common;
using System.ComponentModel.Composition;

namespace Samba.Modules.FastPayModule
{
    [ModuleExport(typeof(FastPayModule))]
    public class FastPayModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        private readonly FastPayModuleView _FastPayModuleView;
        private readonly FastPayModuleViewModel _FastPayModuleViewModel;

        [ImportingConstructor]
        public FastPayModule(IRegionManager regionManager, IUserService userService, FastPayModuleView FastPayModuleView, FastPayModuleViewModel FastPayModuleViewModel)
            : base(regionManager, AppScreens.FastPayView)
        {
            _regionManager = regionManager;
            _userService = userService;
            _FastPayModuleView = FastPayModuleView;
            _FastPayModuleViewModel = FastPayModuleViewModel;

            SetNavigationCommand(Resources.FastPay, Resources.Common, "Images/dcn.png", 50);
            PermissionRegistry.RegisterPermission(PermissionNames.OpenFastPay, PermissionCategories.Navigation, string.Format(Resources.CanNavigate_f, Resources.FastPay));
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(FastPayModuleView));
        }

        protected override bool CanNavigate(string arg)
        {
            return _userService.IsUserPermittedFor(PermissionNames.OpenFastPay);
        }

        protected override void OnNavigate(string obj)
        {
            base.OnNavigate(obj);
            _FastPayModuleViewModel.ActiveUrl = "about:blank";
            _FastPayModuleViewModel.ActiveUrl = "http://www.sambamarket.com/";
        }

        public override object GetVisibleView()
        {
            return _FastPayModuleView;
        }
    }
}
