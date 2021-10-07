using System.Collections.Generic;

namespace MangaDex.Client.Dtos
{
    public class ResultObject<T>
    {
        public string Result { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public int? Total { get; set; }
    }
}