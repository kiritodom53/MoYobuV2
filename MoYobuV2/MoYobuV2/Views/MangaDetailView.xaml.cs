using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaDex.Client.Dtos;
using MoYobuV2.ViewModels;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Backdrop;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoYobuV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MangaDetailView : SfBackdropPage
    {
        private readonly MangaDetailViewModel _viewModel;
        
        private MangaDto _manga;
        private SearchPageViewModel _searchPageViewModel;

        public MangaDetailView(MangaDto manga, SearchPageViewModel searchPageViewModel)
        {
            _manga = manga;
            _searchPageViewModel = searchPageViewModel;
            InitializeComponent();
            _viewModel = new MangaDetailViewModel(_manga);
            BindingContext = _viewModel;

            // Chapters = new ObservableCollection<ChapterDto>();
            //
            // for (int i = 1; i < 54; i++)
            // {
            //     Chapters.Add(new ChapterDto()
            //     {
            //         Attributes = new ChapterAttributeDto()
            //         {
            //             Title = $"#{i:D2} Chapter"
            //         }
            //     });
            // }
            //

            // MangaChaptersListView.ItemsSource = Chapters;
            
            // Todo: put to view model
            
            this.OpenIcon = "outline_expand_more_white_36.png";
            this.CloseIcon = "outline_expand_less_white_36.png";
            
            this.Title = "Menu";
            MangaImg.Source = _manga.Attributes.Cover256;
            // MangaImg.Source =
                // "https://uploads.mangadex.org/covers/95929ed7-6b14-4ce4-820c-3ece99eeccba/7dbca5f9-9fa1-4296-8315-9fd906814911.png.256.jpg";
            MangaTitle.Text = _manga.Attributes.Title.En;
            MangaAuthor.Text = "Author";
            MangaStatus.Text = _manga.Attributes.Status;
            MangaDescription.Text = _manga.Attributes.Description.En;

            // Todo: kliknutí zobrazí mangy s daným tagem
            // foreach (var tag in _manga.Attributes.Tags)
            // {
            //     Tags.Items.Add(new SfChip() { Text = tag.Attributes.Name.En, Margin = new Thickness(3)});
            // }
        }

        private async void MangaChaptersListView_OnSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            // Read

            var chapter = MangaChaptersListView.SelectedItem as ChapterDto;
            
            await Navigation.PushAsync(new ChapterViewer(chapter));
            
            MangaChaptersListView.SelectedItem = null;
        }

        private async void Tags_OnChipClicked(object sender, EventArgs e)
        {
            // Todo: Přejít na pŕedchozí stránku s upraveným filtre
            var chip = sender as SfChip;
            // App.Current.Mainpage.Navigation.PopAsync()
            _searchPageViewModel.ResetFilter();
            // _searchPageViewModel.Filter.SetTagByName(chip?.Text);
            // _searchPageViewModel.TagComedy = true;
            
            // var property = typeof(SearchPageViewModel).GetProperty($"Tag{chip?.Text.Replace(" ", "")}");
            // property.SetValue(typeof(bool?), true, null);

            _searchPageViewModel.ClearList();
            
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}