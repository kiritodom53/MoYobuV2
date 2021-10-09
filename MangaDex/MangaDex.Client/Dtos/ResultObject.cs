using System;
using System.Collections.Generic;

namespace MangaDex.Client.Dtos
{
    public class ResultObject<T>
    {
        private int? _total;
        private int? _offset;

        public string Result { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public int? Limit { get; set; }

        public int? Offset
        {
            get { return _offset; }
            set
            {
                _offset = value;
                if (value.GetValueOrDefault() == 0)
                    Page = 1;
            }
        }

        public int? Total
        {
            get { return _total; }
            set
            {
                _total = value;
                TotalPage = Convert.ToInt32(Math.Ceiling((double)value.GetValueOrDefault() / Limit.GetValueOrDefault()));
                if (Offset != 0)
                {
                    Page = Offset.GetValueOrDefault() / Limit.GetValueOrDefault();
                }

                HasNextPage = Page < TotalPage;
                HasPreviousPage = Offset != 0;
            }
        }

        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}