using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data.Repository
{
    public interface IAlunoRepository:IRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> GetAllAlunosByDisciplinas(int AlunoId);
    }
}
