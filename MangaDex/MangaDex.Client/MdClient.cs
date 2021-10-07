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
        
        private async Task<T> Get<T>(Endpoint endpoint, QueryParameters parameters = null)
        {
            string url = BuildUrl($"{MdConstants.ApiUrl}/{endpoint.GetUrl()}", parameters);

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