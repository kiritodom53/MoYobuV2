using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace MoYobuV2.ChapterViewer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            Img1.Source = ImageSource.FromUri(new Uri("http://uploads.mangadex.org//covers/95929ed7-6b14-4ce4-820c-3ece99eeccba/7dbca5f9-9fa1-4296-8315-9fd906814911.png.256.jpg"));
            
            // var config = new FFImageLoading.Config.Configuration()
            // {
            //     VerboseLogging = true,
            //     ExecuteCallbacksOnUIThread = true,
            //     // HttpClient = _http,
            //     // Logger = new CustomFFLoger()
            // };
            //
            // // ImageService.Instance.Initialize( new CustomFFLoger());
            // ImageService.Instance.Initialize(config);

            // for (int i = 1; i <= 1; i++)
            // {
            //     Grid g = new Grid()
            //     {
            //         HorizontalOptions = LayoutOptions.FillAndExpand,
            //         VerticalOptions = LayoutOptions.FillAndExpand,
            //     };
            //     //
            //     var cachedImage = new Image()
            //     {
            //         HorizontalOptions = LayoutOptions.Center,
            //         VerticalOptions = LayoutOptions.Center,
            //         Aspect = Aspect.AspectFill,
            //     };
            //
            //     // if (i % 2 != 0)
            //     // {
            //     // cachedImage.Source = ImageSource.FromResource($"MoYobuV2.ChapterViewer.Resources.{i:D3}.png");
            //     // }
            //     // else
            //     // {
            //     cachedImage.Source = ImageSource.FromUri(new Uri(
            //         "http://uploads.mangadex.org//covers/95929ed7-6b14-4ce4-820c-3ece99eeccba/7dbca5f9-9fa1-4296-8315-9fd906814911.png.256.jpg"));
            //     // }
            //
            //     // HorizontalOptions="FillAndExpand"
            //     // HeightRequest="{Binding Width, Source={RelativeSource Self}}"
            //     // Aspect="AspectFill"
            //
            //     // Image img = new Image()
            //     // {
            //     //     Margin = new Thickness(0),
            //     //     Aspect = Aspect.AspectFit,
            //     //     // HorizontalOptions = LayoutOptions.FillAndExpand,
            //     //     // VerticalOptions = LayoutOptions.FillAndExpand,
            //     //     Source = ImageSource.FromResource($"MoYobuV2.ChapterViewer.Resources.{i:D3}.png")
            //     // };
            //
            //     g.Children.Add(cachedImage);
            //     ImagesContainer.Children.Add(g);
            // }
        }
    }
}