using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Professor
    {
        public Professor()
        {

        }

        public Professor(int id, string nome, string sobrenome, string telefone, string registro, DateTime dtNascimento, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DtNascimento = dtNascimento;
            this.Registro = registro;
            this.Ativo = ativo;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Registro { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
