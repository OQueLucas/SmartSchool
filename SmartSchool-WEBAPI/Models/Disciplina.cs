using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WEBAPI.Models
{
    public class Disciplina
    {
        public Disciplina() {}
        public Disciplina(int iD, string nome, int professorID) 
        {
            ID = iD;
            Nome = nome;
            ProfessorID = professorID;
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public int ProfessorID { get; set; }
        public Professor Professor { get; set; }
    }
}