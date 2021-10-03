using MoYobuV2.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace MoYobuV2.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        private bool _isLabelVisible = true;
        private bool _isBtnSearchVisible = true;
        private bool _isBtnBackVisible = false;
        private bool _isSearchBarVisible = false;
        
        public ObservableRangeCollection<Manga> MangaList { get; set; }

        public bool IsBtnSearchVisible
        {
            get { return _isBtnSearchVisible; }
            set => SetProperty(ref _isBtnSearchVisible, value);
        }

        public bool IsBtnBackVisible
        {
            get { return _isBtnBackVisible; }
            set => SetProperty(ref _isBtnBackVisible, value);
        }

        public bool IsSearchBarVisible
        {
            get { return _isSearchBarVisible; }
            set => SetProperty(ref _isSearchBarVisible, value);
        }

        public bool IsLabelVisible
        {
            get { return _isLabelVisible; }
            set => SetProperty(ref _isLabelVisible, value);
        }

        public SearchPageViewModel()
        {
            MangaList = new ObservableRangeCollection<Manga>();
        }
        
        public void TestData()
        {
            for (int i = 1; i <= 14; i++)
            {
                MangaList.Add(new Manga("Manga title", ImageSource.FromResource($"MoYobuV2.Images.{i}.png")));
            }
        }
    }
}