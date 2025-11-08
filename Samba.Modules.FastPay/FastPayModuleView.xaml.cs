using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Samba.Modules.FastPayModule
{
    /// <summary>
    /// Interaction logic for MenuModuleView.xaml
    /// </summary>
    
    [Export]
    public partial class FastPayModuleView : UserControl
    {
        [ImportingConstructor]
        public FastPayModuleView(FastPayModuleViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
