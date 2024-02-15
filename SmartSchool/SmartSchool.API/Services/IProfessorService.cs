using SmartSchool.API.Dto.Professor.v1;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Services
{
    public interface IProfessorService
    {
        Task<ProfessorPostDtoResult> InsertAsync(ProfessorPostDto item);
        Task<ProfessorPutDtoResult> UpdateAsync(ProfessorPutDto item);
        Task<bool> DeleteAsync(int Id);
        Task<ProfessorFindDtoResult> FindAsync(int Id);
        Task<PageList<ProfessorFindDtoResult>> FindAsync(PageParams pageParams, Expression<Func<ProfessorFindDto, bool>> predicate = null);

        Task<IEnumerable<ProfessorFindDtoResult>> GetByAlunoId(int AlunoId);
    }
}
