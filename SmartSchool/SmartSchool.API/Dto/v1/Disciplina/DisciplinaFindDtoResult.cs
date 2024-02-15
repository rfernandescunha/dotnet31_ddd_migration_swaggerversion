using SmartSchool.API.Dto.Professor.v1;
using SmartSchool.API.Dto.v1.AlunoDisciplina;
using SmartSchool.API.Dto.v1.Curso;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.v1.Disciplina
{
    public class DisciplinaFindDtoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CargaHoraria { get; set; }
        public int ProfessorId { get; set; }
        //public ProfessorFindDtoResult Professor { get; set; }
        //public int CursoId { get; set; }
        //public CursoFindDtoResult Curso { get; set; }
        //public IEnumerable<AlunoDisciplinaFindDtoResult> AlunoDisciplinas { get; set; }
    }
}
