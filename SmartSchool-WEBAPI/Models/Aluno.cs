namespace SmartSchool_WEBAPI.Models
{
    public class Aluno
    {
        public Aluno() {}
        public Aluno(int iD, string nome, string sobrenome, string telefone) 
        {
            ID = iD;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
        }
        
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
    }
}