namespace TheBestCloth.API.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader
            (
            int currentPage,
            int itemsPerPage,
            int totalItems,
            int totalCount,
            string nextPage,
            string prevPage,
            string firstPage,
            string lastPage
            )
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalCount = totalCount;
            NextPage = nextPage;
            PrevPage = prevPage;
            FirstPage = firstPage;
            LastPage = lastPage;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalCount { get; set; }
        public string NextPage { get; set; }
        public string PrevPage { get; set; }
        public string FirstPage { get; set; }
        public string LastPage { get; set; }
    }
}
