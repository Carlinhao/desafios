using System.Text.Json.Serialization;

namespace crud_pessoa.api.Dtos
{
    public class EnderecoDto
    {
        [JsonPropertyName("pais")]
        public string Pais { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("cidade")]
        public string Cidade { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("rua")]
        public string Rua { get; set; }

        [JsonPropertyName("numero")]
        public int Numero { get; set; }
    }
}
