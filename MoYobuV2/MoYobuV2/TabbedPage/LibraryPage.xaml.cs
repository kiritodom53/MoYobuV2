using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaDex.Client;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryPage : SfTabItem
    {
        public LibraryPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            MdClient md = new MdClient();
            var data = await md.SearchManga();
            var mangaList = data.Data;

            foreach (var manga in mangaList)
            {
                Debug.WriteLine(manga.Attributes.Title.En);
            }
        }
    }
}