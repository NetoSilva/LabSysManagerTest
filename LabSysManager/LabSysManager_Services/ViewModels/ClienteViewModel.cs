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
    }
}
