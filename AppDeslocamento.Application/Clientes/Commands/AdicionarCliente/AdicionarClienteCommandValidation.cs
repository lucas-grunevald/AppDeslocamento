using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Clientes.Commands.AdicionarCliente
{
    public class AdicionarClienteCommandValidation : AbstractValidator<AdicionarClienteCommand>
    {
        public AdicionarClienteCommandValidation()
        {
            RuleFor(d => d.Cpf)
                .NotEmpty().WithMessage("Informe o cpf")
                .Length(11).WithMessage("CPf deve ter apenas 11 caracteres");

            RuleFor(d => d.Nome).NotEmpty().WithMessage("Informe o nome");
        }
    }
}
