using System;
using System.Collections.Generic;
using FFImageLoading.Forms;
using MangaDex.Client.Dtos;
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

            public TempClass(Uri uri)
            {
                Uri = uri;
            }

            public ImageSource ImgSource { get; set; }
            public Uri Uri { get; set; }
        }
        public ObservableRangeCollection<TempClass> Images { get; set; }
        public ObservableRangeCollection<CachedImage> CachedImages { get; set; }
        // public List<string> Chapters { get; set; }

        public ChapterViewerViewModel()
        {
        }

        public ChapterViewerViewModel(ChapterDto chapter)
        {
            // Chapters = chapters;
            CachedImages = new ObservableRangeCollection<CachedImage>();
            Images = new ObservableRangeCollection<TempClass>();

            foreach (string page in chapter.Attributes.DataSaver)
            {
                // var cachedImage = new CachedImage()
                // {
                //     HorizontalOptions = LayoutOptions.FillAndExpand,
                //     VerticalOptions = LayoutOptions.Center,
                //     Aspect = Aspect.AspectFill,
                //     DownsampleToViewSize = true,
                //     BitmapOptimizations = false,
                //     Source = ImageSource.FromUri(new Uri($"https://uploads.mangadex.org/data-saver/{chapter.Attributes.Hash}/{page}"))
                // };
                // //
                // CachedImages.Add(cachedImage);
                Images.Add(new TempClass(new Uri($"https://uploads.mangadex.org/data-saver/{chapter.Attributes.Hash}/{page}")));
                // Images.Add(new TempClass(ImageSource.FromUri(new Uri($"https://uploads.mangadex.org/data/{chapter.Attributes.Hash}/{page}"))));
            }

            // for (int i = 1; i <= 1; i++)
            // {
            //     // Aspect="AspectFill"
            //     // DownsampleToViewSize="true"
            //     // BitmapOptimizations="False"
            //     // HorizontalOptions="FillAndExpand"
            //     // Margin="5"
            //     // https://uploads.mangadex.org/{temporary access token}/data/a4741e1913dd7007a77cf53da281fc59/1-0e0f604924a104a7d02654ed680546487f685712ba4a286c4f1d5c879cf159fa.jpg
            //     var cachedImage = new CachedImage()
            //     {
            //         HorizontalOptions = LayoutOptions.FillAndExpand,
            //         VerticalOptions = LayoutOptions.Center,
            //         Aspect = Aspect.AspectFill,
            //         DownsampleToViewSize = true,
            //         BitmapOptimizations = false,
            //         // Source = ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")
            //         Source = ImageSource.FromUri(new Uri($"https://uploads.mangadex.org/data/{chapter.Attributes.Hash}/{chapter.Attributes.Data}"))
            //     };
            //
            //     CachedImages.Add(cachedImage);
            //     // Images.Add(new TempClass(ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")));
            //
            //     // g.Children.Add(cachedImage);
            //     // ImagesContainer.Children.Add(g);
            //     // _view.ImagesContainer.Children.Add(cachedImage);
            //
            //     // MessageBox.Show("Width: " + img.Width + ", Height: " + img.Height);
            //     // Image img = new Image()
            //     // {
            //     //     Margin = new Thickness(0),
            //     //     Aspect = Aspect.AspectFit,
            //     //     // HorizontalOptions = LayoutOptions.FillAndExpand,
            //     //     // VerticalOptions = LayoutOptions.FillAndExpand,
            //     //     Source = ImageSource.FromResource($"MoYobuV2.ChapterViewer.Resources.{i:D3}.png")
            //     // };
            //
            //     // var cachedImage = new CachedImage() {
            //     //     WidthRequest = 300,
            //     //     HeightRequest = 300,
            //     //     DownsampleToViewSize = true,
            //     //     Source = ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")
            //     // };
            //
            //     // // int h = 0;
            //     // cachedImage.Success += (sender, e) =>
            //     // {
            //     //     var h = e.ImageInformation.OriginalHeight;
            //     //     var w = e.ImageInformation.OriginalWidth;
            //     //     // cachedImage.HeightRequest = h;
            //     // };
            //
            //     // Image im = new Image()
            //     // {
            //     //     Source = ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")
            //     // };
            //     // im.HeightRequest = im.Height;
            //
            //     // Images.Add(new TempClass(cachedImage));
            //
            //     // Images.Add(new TempClass(ImageSource.FromResource($"MoYobuV2.Images.{i:D3}.png")));
            // }
        }
    }
}