using System;
using MangaDex.Client.Filter;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MoYobuV2
{
    public partial class App : Application
    {
        public static MdMangaFilter Filter { get; set; }

        public App()
        {
            //Register Syncfusion comunity license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTA5ODQ1QDMxMzkyZTMzMmUzMGtOS2wyTE5NVzFGUExJRGluZVRlbzdEV3plbUZJOXVaRHVhWk1ZaGFpcms9");
            
            InitializeComponent();
            Filter = new MdMangaFilter();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}