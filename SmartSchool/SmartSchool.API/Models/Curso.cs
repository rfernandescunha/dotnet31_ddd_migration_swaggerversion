using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Curso
    {
        public Curso()
        {

        }

        public Curso(int id, string nome, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
