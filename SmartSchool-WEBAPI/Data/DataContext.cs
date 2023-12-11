using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WEBAPI.Models;

namespace SmartSchool_WEBAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoID, AD.DisciplinaID });

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new (1, "Lauro"),
                    new (2, "Roberto"),
                    new (3, "Ronaldo"),
                    new (4, "Rodrigo"),
                    new (5, "Alexandre"),
                });
            
            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new (1, "Matemática", 1),
                    new (2, "Física", 2),
                    new (3, "Português", 3),
                    new (4, "Inglês", 4),
                    new (5, "Programação", 5)
                });
            
            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new (1, "Marta", "Kent", "33225555"),
                    new (2, "Paula", "Isabela", "3354288"),
                    new (3, "Laura", "Antonia", "55668899"),
                    new (4, "Luíza", "Maria", "6565659"),
                    new (5, "Lucas", "Machado", "565685415"),
                    new (6, "Pedro", "Alvares", "456454545"),
                    new (7, "Paulo", "José", "9874512")
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new () {AlunoID = 1, DisciplinaID = 2 },
                    new () {AlunoID = 1, DisciplinaID = 4 },
                    new () {AlunoID = 1, DisciplinaID = 5 },
                    new () {AlunoID = 2, DisciplinaID = 1 },
                    new () {AlunoID = 2, DisciplinaID = 2 },
                    new () {AlunoID = 2, DisciplinaID = 5 },
                    new () {AlunoID = 3, DisciplinaID = 1 },
                    new () {AlunoID = 3, DisciplinaID = 2 },
                    new () {AlunoID = 3, DisciplinaID = 3 },
                    new () {AlunoID = 4, DisciplinaID = 1 },
                    new () {AlunoID = 4, DisciplinaID = 4 },
                    new () {AlunoID = 4, DisciplinaID = 5 },
                    new () {AlunoID = 5, DisciplinaID = 4 },
                    new () {AlunoID = 5, DisciplinaID = 5 },
                    new () {AlunoID = 6, DisciplinaID = 1 },
                    new () {AlunoID = 6, DisciplinaID = 2 },
                    new () {AlunoID = 6, DisciplinaID = 3 },
                    new () {AlunoID = 6, DisciplinaID = 4 },
                    new () {AlunoID = 7, DisciplinaID = 1 },
                    new () {AlunoID = 7, DisciplinaID = 2 },
                    new () {AlunoID = 7, DisciplinaID = 3 },
                    new () {AlunoID = 7, DisciplinaID = 4 },
                    new () {AlunoID = 7, DisciplinaID = 5 }
                });
        }
    }
}