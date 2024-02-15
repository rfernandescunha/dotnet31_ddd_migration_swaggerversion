using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }

        public Disciplina(int id, string nome, string cargaHoraria, int professorId, int cursoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CargaHoraria { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
