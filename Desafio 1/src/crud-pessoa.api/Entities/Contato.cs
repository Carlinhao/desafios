using System.Text.Json.Serialization;

namespace crud_pessoa.api.Entities
{
    public class Contato : Entity
    {
        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }


        [JsonPropertyName("pessoa_id")]
        public int PessoaId { get; set; }
        
        [JsonPropertyName("pessoa")]
        public Pessoa Pessoa { get; set; }
    }
}
