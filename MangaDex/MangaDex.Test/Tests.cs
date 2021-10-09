using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangaDex.Client;
using MangaDex.Client.Dtos;
using MangaDex.Client.Filter;
using MangaDex.Client.Helpers;
using NUnit.Framework;

namespace MangaDex.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task TestListChapter()
        {
            MdClient client = new MdClient();

            QueryParameters qp = new QueryParameters()
            {
                { "translatedLanguage[]", "en" }
            };

            var data = await client.GetAllMangaChapters("a2febd3e-6252-46eb-bd63-01d51deaaec5", qp);

            
            foreach (var item in data)
            {
                Console.WriteLine(item.Attributes.Title);
            }
        }
        
        [Test]
        public async Task TestGetCover()
        {
            MdClient client = new MdClient();

            var data = await client.GetCover("090e91ae-ad14-4f9c-862a-bea61ac39941");

            Console.WriteLine(data.Data.Attributes.FileName);
        }
        
        [Test]
        public void TestFilter()
        {
            MdMangaFilter fl = new MdMangaFilter();

            fl.SetDemographicNone().SetDemographicShounen()
                .SetOriginalLanguageJapanese()
                .SetStatusCompleted().SetStatusOngoing()
                .SetContentRatingSafe()
                .SetTagReverseHarem().SetTagAction().SetTagCrossdressing().SetTagGenderswap()
                .SetTagPostApocalyptic(null).SetTagOfficialColored(null).SetTagMonsters(null);

            foreach (KeyValuePair<string,string> item in fl.Build())
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
        
        [Test]
        public async Task InitTest()
        {
            MdClient client = new MdClient();

            MdMangaFilter fl = new MdMangaFilter();
            fl.SetDemographicNone().SetDemographicShounen().SetDemographicSeinen()
                .SetOriginalLanguageJapanese()
                .SetStatusCompleted().SetStatusOngoing()
                .SetContentRatingSafe()
                .SetTagAction().SetTagFantasy()
                .SetTagPostApocalyptic(null);
            // var t = fl
                // .Demographic(Demographic.Josei, Demographic.Seinen, Demographic.Shoujo)
                // .Status(Status.Abandoned, Status.Completed);

            var result = await client.SearchManga(fl.Build());
            
            // var result = await client.SearchManga(new QueryParameters()
            // {
            //     { "title", "Isekai" }
            // });

            var m = result.Data;
            foreach (var item in m)
            {
                Console.WriteLine(item.Attributes.Title.En);
            }
        }
    }
}