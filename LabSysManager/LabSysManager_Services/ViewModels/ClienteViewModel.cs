using System;
using System.ComponentModel.DataAnnotations;

namespace LabSysManager_Services.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public long Idade { get; set; }

        public string Rg { get; set; }

        public DateTime DataNasc { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Signo { get; set; }

        public string Mae { get; set; }

        public string Pai { get; set; }

        public string Cep { get; set; }

        public long Numero { get; set; }

        public string Altura { get; set; }

        public long Peso { get; set; }

        public string TipoSanguineo { get; set; }

        public string Cor { get; set; }

        public ClienteViewModel(
             long idade,
             string rg,
             DateTime dataNasc,
             string cidade,
             string estado,
             string signo,
             string mae,
             string pai,
             string cep,
             long numero,
             string altura,
             long peso,
             string tipoSanguineo,
             string cor
             )
        {
            Id = Guid.NewGuid();
            Idade = idade;
            Rg = rg;
            DataNasc = dataNasc;
            Cidade = cidade;
            Estado = estado;
            Signo = signo;
            Mae = mae;
            Pai = pai;
            Cep = cep;
            Numero = numero;
            Altura = altura;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            Cor = cor;
        }

    }
}
