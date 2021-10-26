namespace MangaDex.Client.Dtos
{
    public class CoverDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public CoverAttributesDto Attributes { get; set; }
    }

    public class CoverAttributesDto
    {
        public string Volume { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}