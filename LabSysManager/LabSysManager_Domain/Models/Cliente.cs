using FluentValidation;
using LabSysManager_Domain_Core.Models;
using System;
using System.Runtime.Serialization;

namespace LabSysManager_Domain.Models
{
    public class Cliente : Entity<Cliente>
    {
        public string Nome { get; private set; }

        public long Idade { get; private set; }

        public string Cpf { get; private set; }

        public string Rg { get; private set; }

        public DateTime DataNasc { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string Signo { get; private set; }

        public string Mae { get; private set; }

        public string Pai { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string Cep { get; private set; }

        public long Numero { get; private set; }

        public string TelefoneFixo { get; private set; }

        public string Celular { get; private set; }

        public string Altura { get; private set; }

        public long Peso { get; private set; }

        public ClienteTipoSanguineo TipoSanguineo { get; set; }

        public ClienteCor Cor { get; set; }

        public Cliente(
            string nome,
            long idade,
            string cpf,
            string rg,
            DateTime dataNasc,
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
            ClienteTipoSanguineo tipoSanguineo,
            ClienteCor cor
            )
        {
            Id = Guid.NewGuid();
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

        #region Validações
        public override bool EhValido()
        {
            ValidarNome();
            validationResult = Validate(this);
            return validationResult.IsValid;
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);

        }
        #endregion

        public enum ClienteCor
        {
            Amarelo,
            Azul,
            Laranja,
            Preto,
            Roxo,
            Verde,
            Vermelho
        };

        public enum ClienteTipoSanguineo
        {
            [EnumMember(Value = "A+")]
            APositivo,
            [EnumMember(Value = "A-")]
            ANegativo,
            [EnumMember(Value = "B+")]
            BPositivo,
            [EnumMember(Value = "B-")]
            BNegativo,
            [EnumMember(Value = "AB+")]
            ABPositivo,
            [EnumMember(Value = "AB-")]
            ABNegativo,
            [EnumMember(Value = "O+")]
            OPositivo,
            [EnumMember(Value = "O-")]
            ONegativo
        };
    }
}
