using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TheBestCloth.API.Helpers;

namespace TheBestCloth.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages
            )
        {
            bool hasPrev = false;
            if (currentPage > 1) hasPrev = true;

            bool hasNext = false;
            if (currentPage < totalPages) hasNext = true;

            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage,
                totalItems, totalPages, hasNext, hasPrev);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
