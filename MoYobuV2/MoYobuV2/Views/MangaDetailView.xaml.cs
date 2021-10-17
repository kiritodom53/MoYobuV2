using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaDex.Client.Dtos;
using MoYobuV2.ViewModels;
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
        

        public MangaDetailView(MangaDto manga)
        {
            _manga = manga;
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
            
            // Todo: view model
            
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
            foreach (var tag in _manga.Attributes.Tags)
            {
                Tags.Items.Add(new SfChip() { Text = tag.Attributes.Name.En, Margin = new Thickness(3)});
            }
        }
    }
}