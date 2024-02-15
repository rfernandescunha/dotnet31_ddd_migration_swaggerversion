using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SmartSchoolContext _context;
        private DbSet<T> _dataset;

        public Repository(SmartSchoolContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.LazyLoadingEnabled = false;

            _dataset = context.Set<T>();
        }
        public virtual async Task<T> InsertAsync(T item)
        {

            await _dataset.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public virtual async Task<T> UpdateAsync(T item)
        {

            _context.Entry(item).State = EntityState.Modified;
            _dataset.Update(item);

            //_dataset.Update(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return item;
        }

        public virtual async Task<bool> Update(T obj, params Expression<Func<T, Object>>[] properties)
        {
            //_context.Entry(obj).State = EntityState.Modified;
            _context.Attach(obj).State = EntityState.Modified;

            foreach (var property in properties)
                _context.Entry<T>(obj)
                    .Property(((MemberExpression)property.Body).Member.Name)
                    .IsModified = true;

            await _context.SaveChangesAsync();


            return true;
        }

        public virtual async Task<bool> DeleteAsync(T item)
        {
            _dataset.Remove(item);

            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<T> FindAsync(int Id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;

            return await _dataset.FindAsync(Id);

        }

        public virtual async Task<PageList<T>> FindAsync(PageParams pageParams, Expression<Func<T, bool>> predicate = null)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;

            if (predicate != null)
            {
                var list = await _dataset.AsNoTracking().Where(predicate).ToListAsync();
                var totalItens = list.Count();
                var itens = list.Skip((pageParams.PageNumber - 1) * pageParams.PageSize).Take(pageParams.PageSize).ToList();

                var result = await PageList<T>.CreateAsync(itens, totalItens, pageParams.PageNumber, pageParams.PageSize);

                return result;
            }
            else
            {
                var list = await _dataset.AsNoTracking().ToListAsync();
                var totalItens = list.Count();
                var itens = list.Skip((pageParams.PageNumber - 1) * pageParams.PageSize).Take(pageParams.PageSize).ToList();

                var result =  await PageList<T>.CreateAsync(itens, totalItens, pageParams.PageNumber, pageParams.PageSize);

                return result;
            }
        }

        public virtual async Task<bool> Exist(int Id)
        {
            var resultado = await _dataset.FindAsync(Id);

            return resultado != null;
        }

        public virtual async Task SaveChanges()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

    }
}
