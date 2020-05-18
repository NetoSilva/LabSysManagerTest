using LabSysManager_Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace AtualizadorClientes.DTOs
{
    public class ClienteDTO
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("idade")]
        public long Idade { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("rg")]
        public string Rg { get; set; }

        [JsonProperty("data_nasc")]
        public string DataNasc { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("signo")]
        public string Signo { get; set; }

        [JsonProperty("mae")]
        public string Mae { get; set; }

        [JsonProperty("pai")]
        public string Pai { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("numero")]
        public long Numero { get; set; }

        [JsonProperty("telefone_fixo")]
        public string TelefoneFixo { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("altura")]
        public string Altura { get; set; }

        [JsonProperty("peso")]
        public long Peso { get; set; }

        [JsonProperty("tipo_sanguineo")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Cliente.ClienteTipoSanguineo TipoSanguineo { get; set; }

        [JsonProperty("cor")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Cliente.ClienteCor Cor { get; set; }

        public ClienteDTO(
             string nome,
             long idade,
             string cpf,
             string rg,
             string dataNasc,
             string cidade,
             string estado,
             string signo,
             string mae,
             string pai,
             string email,
             string senha,
             string cep,
             long numero,
             string telefoneFixo,
             string celular,
             string altura,
             long peso,
              Cliente.ClienteTipoSanguineo tipoSanguineo,
              Cliente.ClienteCor cor
             )
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Rg = rg;
            DataNasc = dataNasc;
            Cidade = cidade;
            Estado = estado;
            Signo = signo;
            Mae = mae;
            Pai = pai;
            Email = email;
            Senha = senha;
            Cep = cep;
            Numero = numero;
            TelefoneFixo = telefoneFixo;
            Celular = celular;
            Altura = altura;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            Cor = cor;
        }
    }
}
