using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.Professor.v1
{
    public class ProfessorFindDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Registro { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
