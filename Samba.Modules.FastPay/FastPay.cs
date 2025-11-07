using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Samba.Localization.Properties;
using Samba.Presentation.Common;
using Samba.Presentation.Services.Common;

namespace Samba.Modules.MyCustomModule
{
    [ModuleExport(typeof(MyCustomModule))]
    public class MyCustomModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly MyCustomView _view;

        [ImportingConstructor]
        public MyCustomModule(IRegionManager regionManager, MyCustomView view)
            : base(regionManager, AppScreens.Custom) // you can use AppScreens.TicketView if Custom is not defined
        {
            _regionManager = regionManager;
            _view = view;

            SetNavigationCommand("My Custom", "Common", "Images/MyIcon.png", 99);
        }

        protected override void OnInitialization()
        {
            _regionManager.Regions[RegionNames.MainRegion].Add(_view, "MyCustomView");
        }

        public override object GetVisibleView()
        {
            return _view;
        }
    }
}
