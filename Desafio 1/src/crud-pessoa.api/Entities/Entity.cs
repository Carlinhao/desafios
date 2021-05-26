using System.Text.Json.Serialization;

namespace crud_pessoa.api.Entities
{
    public abstract class Entity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
