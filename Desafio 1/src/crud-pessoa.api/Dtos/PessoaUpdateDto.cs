using System.Text.Json.Serialization;

namespace crud_pessoa.api.Dtos
{
    public class PessoaUpdateDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("contato")]
        public ContatoDto ContatoDto { get; set; }

        [JsonPropertyName("endereco")]
        public EnderecoDto EnderecoDto { get; set; }
    }
}
