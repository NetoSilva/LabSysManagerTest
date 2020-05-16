using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSysManager_Domain_Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Guid Id { get; set; }
        public abstract bool EhValido();

        [NotMapped]
        public ValidationResult validationResult;
        public Entity()
        {
            validationResult = new ValidationResult();
        }
    }
}
