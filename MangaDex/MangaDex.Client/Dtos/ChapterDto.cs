using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MangaDex.Client.Dtos
{
    public class ChapterDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public ChapterAttributeDto Attributes { get; set; }
        public List<RelationshipDto> Relationships { get; set; }
    }

    public class ChapterAttributeDto
    {
        private string _chapter;
        
        public string Title { get; set; }
        public string Volume { get; set; }

        [JsonIgnore]
        public double ChapterD { get; set; }
        [JsonProperty("chapter")]
        public string Chapter
        {
            get { return _chapter; }
            set
            {
                _chapter = value;
                // Todo: vyřešit převod na double s tečkou
                if (!string.IsNullOrEmpty(value))
                    ChapterD = double.Parse(value.Replace('.', ','));
            }
        }

        public string TranslatedLanguage { get; set; }
        public string Hash { get; set; }
        public List<string> Data { get; set; }
        public List<string> DataSaver { get; set; }
        // public string Uploader { get; set; }
        public string ExternalUrl { get; set; }
        public int Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string PublishAt { get; set; }
    }
}