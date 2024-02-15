using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        {

        }

        public AlunoDisciplina(int alunoId, int disciplinaId, int nota)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
            this.Nota = nota;
        }

        public int? Nota { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
