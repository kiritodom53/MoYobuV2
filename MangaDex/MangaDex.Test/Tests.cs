using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangaDex.Client;
using MangaDex.Client.Filter;
using NUnit.Framework;

namespace MangaDex.Test
{
    [TestFixture]
    public class Tests
    {
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