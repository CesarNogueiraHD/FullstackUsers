namespace FullstackUsers.Core.Dtos
{
    public class PagedResult<T>(List<T> items, int totalItems = 0, int totalPages = 1, int currentPage = 1) where T : class
    {
        public List<T> Items { get; private set; } = items;
        public int TotalItems { get; private set; } = totalItems;
        public int TotalPages { get; private set; } = totalPages;
        public bool HasNextPage { get; private set; } = currentPage < totalPages;

        public static PagedResult<T> ReturnPaged(List<T> items, int totalItems, int totalPages, int currentPage)
            => new(items, totalItems, totalPages, currentPage);
    }
}
