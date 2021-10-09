using System;
using System.Diagnostics;
using MangaDex.Client;
using Syncfusion.XForms.TabView;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.Views.TabbedPage
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