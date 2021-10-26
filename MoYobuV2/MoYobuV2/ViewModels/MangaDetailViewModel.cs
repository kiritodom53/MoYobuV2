using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MangaDex.Client;
using MangaDex.Client.Dtos;
using MangaDex.Client.Helpers;
using MvvmHelpers;

namespace MoYobuV2.ViewModels
{
    public class MangaDetailViewModel : ViewModelBase
    {
        public ObservableRangeCollection<ChapterDto> Chapters { get; set; }
        public ObservableRangeCollection<string> Chips { get; set; }
        public MdClient MdClient { get; set; }
        private MangaDto _manga;
        public MangaDetailViewModel(MangaDto manga)
        {
            Chapters = new ObservableRangeCollection<ChapterDto>();
            Chips = new ObservableRangeCollection<string>();
            MdClient = new MdClient();
            _manga = manga;
            LoadChapters();
            LoadChips();
        }

        private void LoadChips()
        {
            foreach (var tag in _manga.Attributes.Tags)
            {
                Chips.Add(tag.Attributes.Name.En);
            }
        }

        private async Task LoadChapters()
        {
            MdClient client = new MdClient();

            QueryParameters qp = new QueryParameters()
            {
                { "translatedLanguage[]", "en" }
            };

            Chapters.AddRange(await client.GetAllMangaChapters(_manga.Id, qp));
        }
    }
}