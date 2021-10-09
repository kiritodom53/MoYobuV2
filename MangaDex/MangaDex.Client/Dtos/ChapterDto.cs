using System;
using System.Collections.Generic;

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
        public string Title { get; set; }
        public string Volume { get; set; }
        public string Chapter { get; set; }
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