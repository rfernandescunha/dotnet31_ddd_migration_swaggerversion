using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public class SmartSchoolContext:DbContext
    {
        public SmartSchoolContext(DbContextOptions<SmartSchoolContext> contextOptions):base(contextOptions)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>().HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });

            builder.Entity<AlunoCurso>().HasKey(AD => new { AD.AlunoId, AD.CursoId });

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "Lauro", "Garcia", "1234567", "00001", new DateTime(), true),
                    new Professor(2, "Roberto", "Silva", "1234567", "00002", new DateTime(), true),
                    new Professor(3, "Ronaldo", "Pereira", "1234567", "00003", new DateTime(), true),
                    new Professor(4, "Rodrigo", "Cunha", "1234567", "00004", new DateTime(), true),
                    new Professor(5, "Alexandre", "Pessoa", "1234567", "00005", new DateTime(), true),
                });

            builder.Entity<Curso>()
    .HasData(new List<Curso>{
                    new Curso(1, "Tec. Informatica", true),
                    new Curso(2, "Sistema de Informação", true),
                    new Curso(3, "Ciencia da Computação", true)
    });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", "10", 1, 1),
                    new Disciplina(2, "Matemática", "10", 1, 3),
                    new Disciplina(3, "Física", "8", 2, 3),
                    new Disciplina(4, "Português", "6", 3, 1),
                    new Disciplina(5, "Inglês", "4", 4,1),
                    new Disciplina(6, "Inglês", "4", 4,2),
                    new Disciplina(7, "Inglês", "5", 4,3),
                    new Disciplina(8, "Programação", "10", 5,1),
                    new Disciplina(9, "Programação", "10", 5,2),
                    new Disciplina(10, "Programação", "10", 5,3)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "Marta", "Kent", "33225555", new DateTime(), "00001", true),
                    new Aluno(2, "Paula", "Isabela", "3354288", new DateTime(), "00002", true),
                    new Aluno(3, "Laura", "Antonia", "55668899", new DateTime(), "00003", true),
                    new Aluno(4, "Luiza", "Maria", "6565659", new DateTime(), "00004", true),
                    new Aluno(5, "Lucas", "Machado", "565685415", new DateTime(), "00005", true),
                    new Aluno(6, "Pedro", "Alvares", "456454545", new DateTime(), "00006", true),
                    new Aluno(7, "Paulo", "José", "9874512", new DateTime(), "00007", true),
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });

        }
    }
}
