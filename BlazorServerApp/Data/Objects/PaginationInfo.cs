using BlazorServerApp.Common;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Data.Objects
{
    public class PaginationInfo<T>
    {
        public List<T> Data { get; set; }
        public int ItemPerPage { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int CurrentBlock { get; set; }
        public int StartPage { get; set; } = 1;
        public int EndPage { get; set; }
        public string SortDirection { get; set; } = "ASC";
        public string SortField { get; set; } = "CreatedDate";

        public bool IsFirstPage
        {
            get
            {
                return (CurrentPage == 1);
            }
        }

        public bool IsLastPage
        {
            get
            {
                return (CurrentPage == TotalPages);
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public static async Task<PaginationInfo<T>> CreatePaginatedListAsync(IQueryable<T> dataSource, PaginationInfo<T> pagingInfo)
        {
            var currentPage = pagingInfo.CurrentPage;
            var itemPerPage = pagingInfo.ItemPerPage;
            var sortDirection = pagingInfo.SortDirection;
            var sortField = pagingInfo.SortField;

            var totalCount = await dataSource.CountAsync();
            var listItem = await dataSource.Skip((currentPage - 1) * itemPerPage).Take(itemPerPage).ToListAsync();
            var totalPages = (totalCount / itemPerPage) % 1 == 0 ? (int)(totalCount / itemPerPage) : (int)(totalCount / itemPerPage) + 1;

            var block = (int) Math.Ceiling((double)currentPage / 5);
            var startPage = block * 5 - 5 + 1;
            var endPage = Math.Min(block*5, totalPages);

            return new PaginationInfo<T>()
            {
                Data = listItem,
                ItemPerPage = itemPerPage,
                CurrentPage = currentPage,
                TotalPages = totalPages,
                TotalCount = totalCount,
                SortDirection = sortDirection,
                CurrentBlock = block,
                SortField = sortField,
                StartPage = startPage,
                EndPage = endPage
            };
        }
    }
}
