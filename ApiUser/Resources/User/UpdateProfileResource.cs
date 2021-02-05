using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Resources.User
{
    public class UpdateProfileResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }


    public class UpdateProfileResourceValidator: AbstractValidator<UpdateProfileResource>
    {
        public UpdateProfileResourceValidator()
        {
            RuleFor(n => n.Name).MaximumLength(50);
            RuleFor(n => n.Surname).MaximumLength(50);
            RuleFor(n => n.Email).EmailAddress().MaximumLength(50);

        }
    }
}
