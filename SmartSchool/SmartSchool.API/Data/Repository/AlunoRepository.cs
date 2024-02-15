using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        private DbSet<Aluno> _dataset;
        public AlunoRepository(SmartSchoolContext context) : base(context)
        {
            _dataset = context.Set<Aluno>();

        }

        public override async Task<Aluno> FindAsync(int Id)
        {
            IQueryable<Aluno> result = _dataset.AsNoTracking().Include(a => a.AlunoDisciplinas)
                .ThenInclude(d=> d.Disciplina)
                .ThenInclude(p=> p.Professor).Where(x => x.Id == Id);

            return await Task.Run(() => result.FirstOrDefault());

        }


        public async Task<IEnumerable<Aluno>> GetAllAlunosByDisciplinas(int AlunoId)
        {
            IQueryable<Aluno> result = _dataset.AsNoTracking()
                .Include(x=> x.AlunoDisciplinas)
                .ThenInclude(d => d.Disciplina)
                .Where(x => x. Id == AlunoId);

            return await Task.Run(() => result);

        }
    }
}
