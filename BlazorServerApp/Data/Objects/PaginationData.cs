using BlazorServerApp.Common;

namespace BlazorServerApp.Data.Objects
{
    public class PaginationData<T>
    {
        public List<T> Data { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int ItemPerPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string SortDirection { get; set; }
        public string SortField { get; set; }
    }
}
