using System;
using System.Threading.Tasks;
using MangaDex.Client.Dtos;
using MangaDex.Client.Filter;
using MoYobuV2.ViewModels;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;

namespace MoYobuV2.Views.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : SfTabItem
    {
        private readonly SearchPageViewModel _viewModel;
        
        // Todo: If offset > limit disable infinite load
        
        public SearchPage()
        {
            InitializeComponent();
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;
        }

        private void BtnSearch_OnClicked(object sender, EventArgs e)
        {
            _viewModel.IsBtnSearchVisible = false;
            _viewModel.IsLabelVisible = false;
            _viewModel.IsBtnBackVisible = true;
            _viewModel.IsSearchBarVisible = true;
        }

        private void BtnBack_OnClicked(object sender, EventArgs e)
        {
            _viewModel.IsBtnSearchVisible = true;
            _viewModel.IsLabelVisible = true;
            _viewModel.IsBtnBackVisible = false;
            _viewModel.IsSearchBarVisible = false;
        }

        private void CbIncludeTagMode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.IncludeTagMode = CbIncludeTagMode.SelectedItem.ToString();
        }

        private void CbExcludeTagMode_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.ExcludeTagMode = CbExcludeTagMode.SelectedItem.ToString();
        }

        private void BtnFilterOpenClose_OnClicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

        private async void MangaListView_OnSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            var manga = MangaListView.SelectedItem as MangaDto;
            if (manga == null) return;
            // await Navigation.PushAsync(new MangaDetailView(manga));
            // new NavigationPage(new MangaDetailView(manga));
            await Navigation.PushAsync(new MangaDetailView(manga, _viewModel));
            // await App.Current.MainPage.Navigation.PushAsync(new MangaDetailView(manga));
            // _fromDetail = true;
            MangaListView.SelectedItem = null;
        }

        private void SfButton_OnClicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();

            Search();
        }

        private void SearchManga_OnSearchButtonPressed(object sender, EventArgs e)
        {
            Search();
        }

        // Todo: if user start search manga by title and previouse searching is stil runnnig then stop and start new searching
        private void Search()
        {
            _viewModel.ClearList();
            // await _viewModel.LoadFirst();
        }

        private void BtnFilterReset_OnClicked(object sender, EventArgs e)
        {
            _viewModel.ResetFilter();
            CbIncludeTagMode.SelectedIndex = 0;
            CbExcludeTagMode.SelectedIndex = 0;
            _viewModel.Filter = new MdMangaFilter();
            // App.Filter = new MdMangaFilter();
            
            _viewModel.ClearList();
            
            navigationDrawer.ToggleDrawer();
        }
    }
}