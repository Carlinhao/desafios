using System.Text.Json.Serialization;

namespace crud_pessoa.api.Dtos
{
    public class PessoaDto
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("contato")]
        public ContatoDto ContatoDto { get; set; }

        [JsonPropertyName("endereco")]
        public EnderecoDto EnderecoDto { get; set; }
    }
}
