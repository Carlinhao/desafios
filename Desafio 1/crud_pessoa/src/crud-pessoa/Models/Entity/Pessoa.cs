using crud_pessoa.VOs;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A idade é obrigatório", AllowEmptyStrings = false)]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O Cpf do usuário é obrigatório", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
    }
}
