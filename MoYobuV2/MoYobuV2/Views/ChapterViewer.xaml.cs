using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoYobuV2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterViewer : ContentPage
    {
        private readonly ChapterViewerViewModel _viewModel;
        public ChapterViewer()
        {
            InitializeComponent();
            _viewModel = new ChapterViewerViewModel();
            BindingContext = _viewModel;

            foreach (var img in _viewModel.CachedImages)
            {
                ImagesContainer.Children.Add(img);
            }
        }
    }
}