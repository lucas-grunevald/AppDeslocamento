using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Queries
{
    public class GetDeslocamentoByIdQuery : IRequest<Deslocamento>
    {
        public long Id { get; set; }
    }

    public class GetDeslocamentoByIdQueryHandler : IRequestHandler<GetDeslocamentoByIdQuery, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentoByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }       

        async public Task<Deslocamento> Handle(GetDeslocamentoByIdQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repository
                .FindBy(d => d.Id == request.Id)
                .Include(d => d.Cliente)
                .Include(d => d.Condutor)
                .Include(d => d.Carro)
                .FirstAsync();

            return deslocamento;
        }
    }
}
