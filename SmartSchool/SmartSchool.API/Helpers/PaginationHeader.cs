using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class PaginationHeader
    {
        public int PageNumber;
        public int TotalPages;
        public int PageSize;
        public int TotalItens;

        public PaginationHeader(int pageNumber, int totalPages, int pageSize, int totalItens)
        {
            this.PageNumber = pageNumber;
            this.TotalPages = totalPages;
            this.PageSize = pageSize;
            this.TotalItens = totalItens;
        }
    }
}
