using System.Text.Json.Serialization;

namespace crud_pessoa.api.Dtos
{
    public class ContatoDto
    {
        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
