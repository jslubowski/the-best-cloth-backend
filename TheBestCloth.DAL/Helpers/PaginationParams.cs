﻿namespace TheBestCloth.DAL.Helpers
{
    public class PaginationParams
    {
        public const int MaxPageSize = 25;
        public int PageNumber { get; set; } = 1;
        private int _pageSize;
        public int PageSize { 
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
    }
}
