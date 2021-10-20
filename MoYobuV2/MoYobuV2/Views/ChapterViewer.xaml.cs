using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using FFImageLoading.Forms;
using MangaDex.Client.Dtos;
using MoYobuV2.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterViewer : ContentPage
    {
        private readonly ChapterViewerViewModel _viewModel;
        private double ratio = 0;

        public ChapterViewer(ChapterDto chapter = null)
        {
            InitializeComponent();
            _viewModel = new ChapterViewerViewModel(chapter);
            BindingContext = _viewModel;

            //     <StackLayout x:Name="ImagesContainer" BackgroundColor="LightPink" Margin="0"
            // Padding="0"
            // HorizontalOptions="FillAndExpand"
            // VerticalOptions="FillAndExpand">
            
            
            // foreach (var img in _viewModel.CachedImages)
            // {
            //     ImagesContainer.Children.Add(img);
            // }
        }

        private void ChapterPages_OnScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            switch (e.ScrollState)
            {
                case ScrollState.Fling:
                    ImageService.Instance.SetPauseWork(true); // all image loading requests will be silently canceled
                    break;
                case ScrollState.Idle:
                    ImageService.Instance.SetPauseWork(false); // loading requests are allowed again
            
                    // Here you should have your custom method that forces redrawing visible list items
                    // ChapterPages
                    break;
            }
        }

        // private void Scroll_OnScrolled(object sender, ScrolledEventArgs e)
        // {
        //     switch (e.ScrollY)
        //     {
        //         case ScrollState.Fling:
        //             ImageService.Instance.SetPauseWork(true); // all image loading requests will be silently canceled
        //             break;
        //         case ScrollState.Idle:
        //             ImageService.Instance.SetPauseWork(false); // loading requests are allowed again
        //     
        //             // Here you should have your custom method that forces redrawing visible list items
        //             // ChapterPages
        //             break;
        //     }
        // }
        
        // private void ChapterPageImage_OnSuccess(object sender, CachedImageEvents.SuccessEventArgs e)
        // {
        //     var image = sender as CachedImage;
        //     double width = e.ImageInformation.OriginalWidth;
        //     double height = e.ImageInformation.OriginalHeight;
        //
        //     ratio = width / height; // store it in a variable
        //     image.HeightRequest = ChapterPages.WidthRequest / ratio;
        // }
        
        // protected override void OnSizeAllocated(double width, double height)
        // {
        //     base.OnSizeAllocated(width, height);
        //     // if (this.Width > 0 && ratio != 0) // width of the parent container
        //         // chapterPageImage.HeightRequest = this.Width / ratio;
        // }
        private void ChapterPageImage_OnSuccess(object sender, CachedImageEvents.SuccessEventArgs e)
        {
            var image = sender as CachedImage;
            // double width = e.ImageInformation.OriginalWidth;
            // double height = e.ImageInformation.OriginalHeight;
            
            // Debug.WriteLine("here");
            // Debug.WriteLine(e.ImageInformation.OriginalWidth.DpToPixels());
            // Debug.WriteLine(e.ImageInformation.OriginalWidth.PixelsToDp());
            // Debug.WriteLine(e.ImageInformation.OriginalWidth.HighestOneBit());
            // image.HeightRequest = e.ImageInformation.OriginalHeight;
            // image.WidthRequest = width;
        }
    }
}