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
        public MdClient MdClient { get; set; }
        private MangaDto _manga;
        public MangaDetailViewModel(MangaDto manga)
        {
            Chapters = new ObservableRangeCollection<ChapterDto>();
            MdClient = new MdClient();
            _manga = manga;
            LoadChapters();
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