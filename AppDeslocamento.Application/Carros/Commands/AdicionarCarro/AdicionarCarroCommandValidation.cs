using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Carros.Commands
{
    public class AdicionarCarroCommandValidation : AbstractValidator<AdicionarCarroCommand>
    {
        public AdicionarCarroCommandValidation()
        {
            RuleFor(d => d.Placa)
                .NotEmpty().WithMessage("Informe a placa")
                .MaximumLength(10).WithMessage("A placa deve ter no máximo 10 caracteres");

            RuleFor(d => d.Descricao)
                .NotEmpty().WithMessage("Informe a descrição")
                .MaximumLength(255).WithMessage("A descrição deve ter no máximo 255 caracteres");
        }
    }
}
