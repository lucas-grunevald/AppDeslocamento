using AppDeslocamento.Data.Context;
using AppDeslocamento.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class IniciarDeslocamentoCommandValidation : AbstractValidator<IniciarDeslocamentoCommand>
    {

        private readonly ApplicationDbContext _context;
        public IniciarDeslocamentoCommandValidation(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(c => c.CondutorId)
                .NotNull().WithMessage("Informe o id do condutor")
                .MustAsync(MustFindCondutorById).WithMessage("Condutor não encontrado");                

            RuleFor(c => c.CarroId)
                .NotNull().WithMessage("Informe o id do carro")
                .MustAsync(MustFindCarroById).WithMessage("Carro não encontrado");

            RuleFor(c => c.ClienteId)
                .NotNull().WithMessage("Informe o id do cliente")
                .MustAsync(MustFindClienteById).WithMessage("Cliente não encontrado");

            RuleFor(c => c.QuilometragemInicial)
                .NotNull().WithMessage("Informe a quilometragem inicial")
                .GreaterThan(0).WithMessage("A quilometragem inicial deve ser maior que 0");

            RuleFor(c => c)
                .MustAsync(MustBeUnique).WithMessage("Já existe um deslocamento aberto");
        }

        public async Task<bool> MustFindCarroById(long id, CancellationToken cancellationToken)
        {
            return await _context.Carros.FindAsync(id) != null;
        }

        public async Task<bool> MustFindCondutorById(long id, CancellationToken cancellationToken)
        {
            return await _context.Condutores.FindAsync(id) != null;
        }

        public async Task<bool> MustFindClienteById(long id, CancellationToken cancellationToken)
        {
            return await _context.Clientes.FindAsync(id) != null;
        }

        public async Task<bool> MustBeUnique(IniciarDeslocamentoCommand d, CancellationToken cancellationToken)
        {
            if (!_context.Deslocamentos.Any())
                return true;

            var deslocamento = await _context.Deslocamentos
                .Where(p => p.CondutorId == d.CondutorId)
                .Where(p => p.ClienteId == d.ClienteId)
                .Where(p => p.CarroId == d.CarroId)
                .OrderByDescending(p => p.Id)
                .FirstAsync();

            if (deslocamento != null)
            {
                if(deslocamento.DataHoraFim != null) 
                    return true;
            }

            return false;
        }
    }
}
