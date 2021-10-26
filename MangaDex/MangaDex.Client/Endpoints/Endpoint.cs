namespace MangaDex.Client.Endpoints
{
    public class Endpoint
    {
        private string[] _parts;

        public Endpoint(params string[] parts)
        {
            _parts = parts;
        }

        public string GetUrl()
        {
            return string.Join("/", _parts);
        }
    }
}