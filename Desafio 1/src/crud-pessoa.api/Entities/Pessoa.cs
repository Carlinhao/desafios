using System.Text.Json.Serialization;

namespace crud_pessoa.api.Entities
{    
    public class Pessoa : Entity
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("contato")]
        public Contato Contato { get; set; }

        [JsonPropertyName("endereco")]
        public Endereco Endereco { get; set; }
    }
}
