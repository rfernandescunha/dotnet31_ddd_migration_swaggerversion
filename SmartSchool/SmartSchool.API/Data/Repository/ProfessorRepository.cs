using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Data.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        private DbSet<Professor> _dataset;
        public ProfessorRepository(SmartSchoolContext context) : base(context)
        {
            _dataset = context.Set<Professor>();

        }

        public override async Task<Professor> FindAsync(int Id)
        {
            IQueryable<Professor> result = _dataset.AsNoTracking().Include(a => a.Disciplinas).Where(x => x.Id == Id);

            return await Task.Run(() => result.FirstOrDefault());

        }

        public override async Task<PageList<Professor>> FindAsync(PageParams pageParams, Expression<Func<Professor, bool>> predicate = null)
        {
            _context.ChangeTracker.LazyLoadingEnabled = false;

            if (predicate != null)
            {
                var list = await _dataset.AsNoTracking().Include(x=> x.Disciplinas).Where(predicate).ToListAsync();
                var totalItens = list.Count();
                var itens = list.Skip((pageParams.PageNumber - 1) * pageParams.PageSize).Take(pageParams.PageSize).ToList();

                var result = await PageList<Professor>.CreateAsync(itens, totalItens, pageParams.PageNumber, pageParams.PageSize);

                return result;
            }
            else
            {
                var list = await _dataset.AsNoTracking().Include(x => x.Disciplinas).ToListAsync();
                var totalItens = list.Count();
                var itens = list.Skip((pageParams.PageNumber - 1) * pageParams.PageSize).Take(pageParams.PageSize).ToList();

                var result = await PageList<Professor>.CreateAsync(itens, totalItens, pageParams.PageNumber, pageParams.PageSize);

                return result;
            }
        }

        public async Task<IEnumerable<Professor>> GetByAlunoId(int AlunoId)
        {
            IQueryable<Professor> result = _dataset.AsNoTracking()
                .Include(x=> x.Disciplinas)
                .Where(d => d.Disciplinas.Any(ad=> ad.AlunoDisciplinas.Any(a=> a.AlunoId == AlunoId)));

            return await Task.Run(() => result);

        }

    }
}
