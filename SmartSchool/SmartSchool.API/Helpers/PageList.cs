using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class PageList<T>:List<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItens { get; set; }

        public PageList(List<T> itens, int totalItens, int pageNumber, int pageSize)
        {
            TotalItens = totalItens;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(totalItens / (double)pageSize);
            this.AddRange(itens);
        }


        public static async Task<PageList<T>> CreateAsync(IEnumerable<T> source, int totalItens, int pageNumber, int pageSize)
        {
            var result = new PageList<T>(source.ToList(), totalItens, pageNumber, pageSize);
            return await Task.Run(() => result);
        }
    }
}
