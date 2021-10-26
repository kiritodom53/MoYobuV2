using System;
using System.Collections.Generic;
using System.Security.Policy;
using Newtonsoft.Json;

namespace MangaDex.Client.Dtos
{
    public class MangaDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public MangaAttributesDto Attributes { get; set; }
        public List<RelationshipDto> Relationships { get; set; }
    }

    public class MangaAttributesDto
    {
        public LanguageValues Title { get; set; }
        public LanguageValues AltTitle { get; set; }
        public LanguageValues Description { get; set; }
        public bool IsLocked { get; set; }
        // public dynamic Links { get; set; }
        public string OriginalLanguage { get; set; }
        public string LastVolume { get; set; }
        public string LastChapter { get; set; }
        public string PublicationDemographic { get; set; }
        public string Status { get; set; }
        public int? Year { get; set; }
        public string ContentRating { get; set; }
        public List<TagsDto> Tags { get; set; }
        public int? Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        [JsonIgnore]
        public string Cover256 { get; set; }
        [JsonIgnore]
        public Uri Cover256Uri { get; set; }
        //https://uploads.mangadex.org/covers/{ manga.id }/{ cover.filename }.256.jpg
    }
    
    public class LanguageValues
    {
        public string En { get; set; }
    }

    public class RelationshipDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        // public string Related { get; set; }
        // public dynamic Attributes { get; set; } // include atributy
    }
}