namespace MangaDex.Client.Helpers
{
    public class MdConstants
    {
        public const string UuidRegex = "[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}";

        public const int MangaLimit = 20;
        public const int LatestChapterLimit = 20;

        public const string Manga = "manga";
        public const string CoverArt = "cover_art";
        public const string Scanlator = "scanlation_group";
        public const string Author = "author";
        public const string Artist = "artist";

        public const string ApiUrl = "https://api.mangadex.org";
        public const string ApiMangaUrl = "https://api.mangadex.org/manga";
        public const string ApiChapterUrl = "https://api.mangadex.org/chapter";

        public const string ApiCover256Url = "https://uploads.mangadex.org/covers";

        public const string CoverQualityPref = "thumbnailQuality";
    }
}