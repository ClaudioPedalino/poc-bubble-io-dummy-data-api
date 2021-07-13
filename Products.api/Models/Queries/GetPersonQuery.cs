using Products.api.Models.Common;

namespace Products.api.Models.Queries
{
    public class GetPersonQuery : PaginationQuery
    {
        public string Search { get; set; }
    }
}