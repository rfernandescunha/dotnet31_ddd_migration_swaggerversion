using SmartSchool.API.Dto.v1.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.v1.Curso
{
    public class CursoFindDtoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<DisciplinaFindDtoResult> Disciplinas { get; set; }
    }
}
