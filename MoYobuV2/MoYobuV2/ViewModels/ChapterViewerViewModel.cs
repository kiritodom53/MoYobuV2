using System;
using FFImageLoading.Forms;
using MoYobuV2.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace MoYobuV2.ViewModels
{
    public class ChapterViewerViewModel : ViewModelBase
    {
        public class TempClass
        {
            public TempClass(ImageSource imgSource)
            {
                ImgSource = imgSource;
            }
            public ImageSource ImgSource { get; set; }
        }
        public ObservableRangeCollection<TempClass> Images { get; set; }
        public ObservableRangeCollection<CachedImage> CachedImages { get; set; }

        public ChapterViewerViewModel()
        {
            CachedImages = new ObservableRangeCollection<CachedImage>();
            Images = new ObservableRangeCollection<TempClass>();

            for (int i = 1; i <= 1; i++)
            {
                // Aspect="AspectFill"
                // DownsampleToViewSize="true"
                // BitmapOptimizations="False"
                // HorizontalOptions="FillAndExpand"
                // Margin="5"
                var cachedImage = new CachedImage()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Aspect = Aspect.AspectFill,
                    DownsampleToViewSize = true,
                    BitmapOptimizations = false,
                    // Source = ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")
                    Source = ImageSource.FromUri(new Uri("https://uploads.mangadex.org//covers/fffbfac3-b7ad-41ee-9581-b4d90ecec941/3787d628-0387-43ea-b732-3b9015584c0b.jpg.256.jpg"))
                };

                CachedImages.Add(cachedImage);
                // Images.Add(new TempClass(ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")));

                // g.Children.Add(cachedImage);
                // ImagesContainer.Children.Add(g);
                // _view.ImagesContainer.Children.Add(cachedImage);

                // MessageBox.Show("Width: " + img.Width + ", Height: " + img.Height);
                // Image img = new Image()
                // {
                //     Margin = new Thickness(0),
                //     Aspect = Aspect.AspectFit,
                //     // HorizontalOptions = LayoutOptions.FillAndExpand,
                //     // VerticalOptions = LayoutOptions.FillAndExpand,
                //     Source = ImageSource.FromResource($"MoYobuV2.ChapterViewer.Resources.{i:D3}.png")
                // };

                // var cachedImage = new CachedImage() {
                //     WidthRequest = 300,
                //     HeightRequest = 300,
                //     DownsampleToViewSize = true,
                //     Source = ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")
                // };

                // // int h = 0;
                // cachedImage.Success += (sender, e) =>
                // {
                //     var h = e.ImageInformation.OriginalHeight;
                //     var w = e.ImageInformation.OriginalWidth;
                //     // cachedImage.HeightRequest = h;
                // };

                // Image im = new Image()
                // {
                //     Source = ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")
                // };
                // im.HeightRequest = im.Height;

                // Images.Add(new TempClass(cachedImage));

                // Images.Add(new TempClass(ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")));
            }
        }
    }
}