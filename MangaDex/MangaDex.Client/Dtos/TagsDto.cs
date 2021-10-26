using Newtonsoft.Json;

namespace MangaDex.Client.Dtos
{
    public class TagsDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public TagAttributesDto Attributes { get; set; }
    }

    public class TagAttributesDto
    {
        [JsonProperty("name")]
        public TagName Name { get; set; }
        // [JsonProperty("description")]
        // public TagDescription Description { get; set; }
        public string Group { get; set; }
        public int Version { get; set; }
    }
    
    public class TagName
    {
        public string En { get; set; }
    }
    
    public class TagDescription
    {
        public string En { get; set; }
    }
}