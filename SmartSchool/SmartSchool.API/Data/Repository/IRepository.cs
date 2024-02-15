using SmartSchool.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
        Task<T> FindAsync(int Id);
        Task<PageList<T>> FindAsync(PageParams pageParams, Expression<Func<T, bool>> predicate = null);
    }
}
