using SmartSchool.API.Dto.v1.AlunoDisciplina;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.Aluno.v1
{
    public class AlunoFindDtoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplinaFindDtoResult> AlunoDisciplinas { get; set; }
        
    }
}
