﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBestCloth.BLL.Helpers
{
    public class IEnumerable<T> : List<T>
    {
        public IEnumerable(System.Collections.Generic.IEnumerable<T> items, int currentPage, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling(totalCount / (double)pageSize);
            PageSize = pageSize;
            TotalCount = totalCount;
            AddRange(items);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<IEnumerable<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new IEnumerable<T>(items, pageNumber, pageSize, count);
        }
    }
}
