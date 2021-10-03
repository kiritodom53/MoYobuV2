using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : SfTabItem
    {
        public TestPage()
        {
            InitializeComponent();
        }
    }
}