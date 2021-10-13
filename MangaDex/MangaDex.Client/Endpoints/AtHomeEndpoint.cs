namespace MangaDex.Client.Endpoints
{
    public class AtHomeEndpoint : Endpoint
    {
        public AtHomeEndpoint(string chapterId) : base("at-home", "server", chapterId)
        {
        }
    }
}