using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using TheBestCloth.API.Helpers;

namespace TheBestCloth.API.Extensions
{
    public static class HttpExtensions
    {
        private static readonly int _firstPage = 1;
        public static void AddPaginationHeader(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages
            )
        {
            var request = response.HttpContext.Request;

            var firstPage = CreateNavigationUri(_firstPage, itemsPerPage, request);

            var lastPage = CreateNavigationUri(totalPages, itemsPerPage, request);

            var nextPage = (currentPage < totalPages)
                ? CreateNavigationUri(currentPage + 1, itemsPerPage, request)
                : "";

            var prevPage = (currentPage > 1)
                ? CreateNavigationUri(currentPage - 1, itemsPerPage, request)
                : "";
            
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage,
                totalItems, totalPages, nextPage, prevPage, firstPage, lastPage);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", Regex.Unescape(JsonSerializer.Serialize(paginationHeader, options)));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        private static string CreateNavigationUri(int page, int pageSize, HttpRequest request)
        {
            var uri = new UriBuilder();
            uri.Scheme = request.Scheme;
            uri.Host = request.Host.Host;
            uri.Port = request.Host.Port.GetValueOrDefault();
            uri.Path = request.Path;
            uri.Query = $"pageNumber={page}&pageSize={pageSize}";
            return uri.ToString();
        }
    }
}
