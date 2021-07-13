using System.Collections.Generic;

namespace Products.api.Models
{
    public class DataResult<T>
    {
        public DataResult()
        {
            HasErrors = false;
            Messages = new List<string>();
        }

        public bool HasErrors { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IList<string> Messages { get; set; }
        public IEnumerable<T> Data { get; set; }

        public static DataResult<T> Success(IEnumerable<T> data, int totalCount, int pageSize, int totalPages)
            => new DataResult<T>()
            {
                HasErrors = false,
                Messages = new List<string>() { string.Empty },
                Data = data,
                TotalCount = totalCount,
                PageSize = pageSize,
                TotalPages = totalPages
            };

        public static DataResult<T> Fail(string message)
            => new DataResult<T>() { HasErrors = true, Messages = new List<string>() { message }, Data = default };

        public static DataResult<T> NotFound(string message)
            => new DataResult<T>() { HasErrors = true, Messages = new List<string>() { message }, Data = default };
    }
}