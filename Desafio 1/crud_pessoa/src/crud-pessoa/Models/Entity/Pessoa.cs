using crud_pessoa.VOs;

namespace crud_pessoa.Models.Entity
{
    public class Pessoa : Entity
    {
        public Contato Contato { get; set; }
        public Endereco Endereco { get; set; }
    }
    

    public abstract class Entity
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
