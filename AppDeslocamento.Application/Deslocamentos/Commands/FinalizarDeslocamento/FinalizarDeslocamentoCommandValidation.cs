using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Commands.FinalizarDeslocamento
{
    public class FinalizarDeslocamentoCommandValidation : AbstractValidator<FinalizarDeslocamentoCommand>
    {
        public FinalizarDeslocamentoCommandValidation()
        {
            RuleFor(c => c.QuilometragemFinal)
                .NotNull().WithMessage("Informe a quilometragem final")
                .GreaterThan(0).WithMessage("Quilometragem final deve se maior que 0");            

            
        }
    }
}
