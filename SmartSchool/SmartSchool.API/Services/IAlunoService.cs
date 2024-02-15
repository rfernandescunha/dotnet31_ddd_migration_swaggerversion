using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Dto.v1.Disciplina;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartSchool.API.Services
{
    public interface IAlunoService
    {
        Task<AlunoPostDtoResult> InsertAsync(AlunoPostDto item);
        Task<AlunoPutDtoResult> UpdateAsync(AlunoPutDto item);
        Task<bool> DeleteAsync(int Id);
        Task<AlunoFindDtoResult> FindAsync(int Id);
        Task<PageList<AlunoFindDtoResult>> FindAsync(PageParams pageParams, Expression<Func<AlunoFindDto, bool>> predicate = null);

        Task<IEnumerable<AlunoFindDtoResult>> GetAllAlunosByDisciplinas(int AlunoId);
    }
}
