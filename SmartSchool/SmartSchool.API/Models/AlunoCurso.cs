using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class AlunoCurso
    {
        public AlunoCurso()
        {

        }

        public AlunoCurso(int alunoId, int cursoId, bool ativo)
        {
            this.AlunoId = alunoId;
            this.CursoId = cursoId;
            this.Ativo = ativo;
        }
        public bool Ativo { get; set; } = true;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
