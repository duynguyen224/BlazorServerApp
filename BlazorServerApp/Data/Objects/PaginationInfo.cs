using BlazorServerApp.Common;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BlazorServerApp.Data.Objects
{
    public class PaginationInfo<T>
    {
        public List<T> Data { get; set; }
        public int ItemPerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int CurrentBlock { get; set; }
        public int PagePerBlock { get; set; } = 5;
        public int StartPage { get; set; } = 1;
        public int EndPage { get; set; }
        public string SortDirection { get; set; } = "ASC";
        public string SortField { get; set; } = "CreatedDate";

        public bool IsFirstBlock
        {
            get
            {
                return (CurrentBlock == 1);
            }
        }

        public bool IsLastBlock
        {
            get
            {
                return (CurrentBlock == (int)Math.Ceiling(((double) TotalCount / ItemPerPage) / PagePerBlock));
            }
        }

        public static async Task<PaginationInfo<T>> CreatePaginatedListAsync(IQueryable<T> dataSource, PaginationInfo<T> pagingInfo)
        {
            var currentPage = pagingInfo.CurrentPage;
            var itemPerPage = pagingInfo.ItemPerPage;
            var sortDirection = pagingInfo.SortDirection;
            var sortField = pagingInfo.SortField;
            var pagePerBlock = pagingInfo.PagePerBlock;

            var totalCount = await dataSource.CountAsync();
            var listItem = await dataSource.Skip((currentPage - 1) * itemPerPage).Take(itemPerPage).ToListAsync();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / itemPerPage);

            var block = (int)Math.Ceiling((double)currentPage / pagePerBlock);
            var startPage = block * pagePerBlock - pagePerBlock + 1;
            var endPage = Math.Min(block * 5, totalPages);

            return new PaginationInfo<T>()
            {
                Data = listItem,
                ItemPerPage = itemPerPage,
                CurrentPage = currentPage,
                TotalPages = totalPages,
                TotalCount = totalCount,
                SortDirection = sortDirection,
                CurrentBlock = block,
                PagePerBlock = pagePerBlock,
                SortField = sortField,
                StartPage = startPage,
                EndPage = endPage
            };
        }
    }
}
