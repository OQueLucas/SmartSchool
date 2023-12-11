using System.Collections.Generic;

namespace SmartSchool_WEBAPI.Models
{
    public class Professor
    {
        public Professor() {}
        public Professor(int iD, string nome) 
        {
            ID = iD;
            Nome = nome;
        }
        
        public int ID { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}