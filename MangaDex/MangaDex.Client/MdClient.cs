using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using MangaDex.Client.Dtos;
using MangaDex.Client.Endpoints;
using MangaDex.Client.Helpers;
using Newtonsoft.Json;

namespace MangaDex.Client
{
    public class MdClient
    {
        private HttpClient _client;

        public MdClient()
        {
            _client = new HttpClient();
        }

        // Todo: chapters
        // kapitoly - https://api.mangadex.org/chapter?limit=100&translatedLanguage[]=en&manga=<uuid>

        // Todo: img server
        // https://uploads.mangadex.org/<token?>/<data/data-saver>/<chapter_hash>/<filename>

        // Todo: server pro kapitoly
        // https://api.mangadex.org/at-home/server/<chapterId>

        // podle offsetu sebrat všechno

        public async Task<ResultObject<List<ChapterDto>>> GetMangaChapters(string mangaId,
            QueryParameters parameters = null)
        {
            if (parameters == null)
                parameters = new QueryParameters();

            parameters.Add("manga", mangaId);

            return await Get<ResultObject<List<ChapterDto>>>(new ChapterListEndpoint(), parameters);
        }

        public async Task<List<ChapterDto>> GetAllMangaChapters(string mangaId,
            QueryParameters parameters = null)
        {
            if (parameters == null)
                parameters = new QueryParameters();
            parameters.Add("manga", mangaId);

            int limit = 100;
            int offset = 0;

            QueryParameters q = new QueryParameters(parameters)
            {
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }
            };

            var d = await Get<ResultObject<List<ChapterDto>>>(new ChapterListEndpoint(), q);
            var dd = d.Data;

            for (int i = 1;
                i < Convert.ToInt32(
                    Math.Ceiling((double)d.Total.GetValueOrDefault() / d.Limit.GetValueOrDefault()));
                i++)
            {
                offset += limit;
                QueryParameters qTemp = new QueryParameters(parameters)
                {
                    { "limit", limit.ToString() },
                    { "offset", offset.ToString() }
                };
                var temp = await Get<ResultObject<List<ChapterDto>>>(new ChapterListEndpoint(), qTemp);
            }

            return dd;

            // List<ChapterDto> chapters = null;
            //
            // bool hasNextPage = true;
            // bool firstRun = true;
            // int offset = 0;
            // int limit = 100;
            //
            // while (hasNextPage)
            // {
            //     QueryParameters q = new QueryParameters(parameters)
            //     {
            //         { "limit", limit.ToString() },
            //         { "offset", offset.ToString() }
            //     };
            //
            //     var d = await Get<ResultObject<List<ChapterDto>>>(new ChapterListEndpoint(), q);
            //
            //     if (firstRun)
            //     {
            //         chapters = d.Data;
            //         firstRun = false;
            //     }
            //     else chapters.AddRange(d.Data);
            //
            //     Console.WriteLine($"page: {d.Page}");
            //
            //     offset += limit;
            //     hasNextPage = d.HasNextPage;
            // }

            // return await Get<List<ChapterDto>>(new ChapterListEndpoint(), parameters);
        }


        public async Task<ResultObject<CoverDto>> GetCover(string id)
        {
            return await Get<ResultObject<CoverDto>>(new GetCoverEndpoint(id));
        }

        // Todo: nějak to pořešit
        public async Task<ResultObject<List<MangaDto>>> SearchManga(QueryParameters parameters = null)
        {
            // parameters.Add();
            return await Get<ResultObject<List<MangaDto>>>(new MangaListEndpoint(), parameters);
        }

        private async Task<T> Get<T>(Endpoint endpoint, QueryParameters parameters = null,
            string baseUrl = MdConstants.ApiUrl)
        {
            string url = BuildUrl($"{baseUrl}/{endpoint.GetUrl()}", parameters);

            HttpResponseMessage response =
                await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(response.StatusCode.ToString());
            }

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        private string BuildUrl(string url, QueryParameters parameters)
        {
            var builder = new UriBuilder(url);

            // if (parameters != null || size.Length != 0)
            builder.Query = Helper.EncodeDictionary(parameters);

            Console.WriteLine(builder.ToString());
            var t = builder.ToString();

            return builder.ToString();
        }
    }
}