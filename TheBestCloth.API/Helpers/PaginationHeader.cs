namespace TheBestCloth.API.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int myProperty, bool hasNext, bool hasPrev)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            MyProperty = myProperty;
            HasNext = hasNext;
            HasPrev = hasPrev;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int MyProperty { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
    }
}
