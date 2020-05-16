using Newtonsoft.Json;

namespace AtualizadorClientes.DTOs
{
    public class EnderecoDTO
    {
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cep")]
        public long Cep { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("complemento2")]
        public string Complemento2 { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("unidadesPostagem")]
        public object UnidadesPostagem { get; set; }
    }
}
