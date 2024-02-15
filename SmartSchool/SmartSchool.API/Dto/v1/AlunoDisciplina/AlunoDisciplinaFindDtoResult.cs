using SmartSchool.API.Dto.Aluno.v1;
using SmartSchool.API.Dto.v1.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.v1.AlunoDisciplina
{
    public class AlunoDisciplinaFindDtoResult
    {
        public int? Nota { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public int AlunoId { get; set; }
        public AlunoFindDto Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public DisciplinaFindDtoResult Disciplina { get; set; }
    }
}
