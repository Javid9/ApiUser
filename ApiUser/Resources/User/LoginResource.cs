using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Resources.User
{
    public class LoginResource
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class LoginResourceValidator: AbstractValidator<LoginResource>
    {
        public LoginResourceValidator()
        {
            RuleFor(e => e.Email).EmailAddress().MaximumLength(50).NotNull();
            RuleFor(p => p.Password).MinimumLength(6).MaximumLength(100).NotNull();
        }
    }
}
