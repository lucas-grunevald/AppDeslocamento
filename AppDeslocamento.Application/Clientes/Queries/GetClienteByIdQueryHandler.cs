using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Clientes.Queries
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public long clienteId { get; set; }
    }

    public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClienteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(
            GetClienteByIdQuery request,
            CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Cliente>();

            var cliente = await repository
                .GetByIdAsync(request.clienteId);

            return cliente;
        }
    }
}
