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
                Images.Add(new TempClass(new Uri($"https://uploads.mangadex.org/data-saver/{chapter.Attributes.Hash}/{page}")));
            }
        }
    }
}