using System.Text.Json;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace Service.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, 
            int itemsForPage, int totalItems, int totalPages) {
                var paginationHeader = new PaginationHeader(currentPage, itemsForPage, totalItems, totalPages);
                var options = new JsonSerializerOptions{
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
                response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            }
    }
}