using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Dto.Aluno.v1
{
    /// <summary>
    /// Dto para salvar aluno
    /// </summary>
    public class AlunoPostDto
    {
        /// <summary>
        /// Nome do aluno
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do aluno
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Telefone do aluno
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Matricula do aluno
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Data de nascimento do aluno
        /// </summary>
        public DateTime DtNascimento { get; set; }
        /// <summary>
        /// Status do Aluno
        /// </summary>
        public bool Ativo { get; set; }
        /// <summary>
        /// Lista de disciplina do aluno
        /// </summary>
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
