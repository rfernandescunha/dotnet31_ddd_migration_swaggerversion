﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }

        public Aluno(int id, string nome, string sobrenome, string telefone, DateTime dtNascimento, string matricula, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DtNascimento = dtNascimento;
            this.Matricula = matricula;
            this.Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Matricula { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunoDisciplinas { get; set; }
    }
}
