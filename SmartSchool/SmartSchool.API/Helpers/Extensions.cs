using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public static class Extensions
    {
        public static void AddPagination(
                                        this HttpResponse response,
                                        int pageNumber,
                                        int totalPages,
                                        int pageSize,
                                        int totalItens)
        {

            var paginationHeader = new PaginationHeader(pageNumber, totalPages, pageSize, totalItens);

            var json =  JsonConvert.SerializeObject(paginationHeader);

            response.Headers.Add("Pagination", json);
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");

        }
    }
}
