using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Condutores.Commands
{
    public class AdicionarCondutorCommandValidation : AbstractValidator<AdicionarCondutorCommand>
    {
        public AdicionarCondutorCommandValidation()
        {
            RuleFor(d => d.Email).EmailAddress().WithMessage("Informe um email válido");

            RuleFor(d => d.Nome).NotEmpty().WithMessage("Informe o nome");
        }
    }
}
