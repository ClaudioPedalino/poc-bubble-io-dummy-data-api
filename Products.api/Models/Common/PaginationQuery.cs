namespace Products.api.Models.Common
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}