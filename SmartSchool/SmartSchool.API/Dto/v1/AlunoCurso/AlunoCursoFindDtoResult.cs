using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Dto.v1.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.v1.AlunoCurso
{
    public class AlunoCursoFindDtoResult
    {
        public bool Ativo { get; set; } = true;
        public int AlunoId { get; set; }
        public AlunoFindDtoResult Aluno { get; set; }
        public int CursoId { get; set; }
        public CursoFindDtoResult Curso { get; set; }
    }
}
