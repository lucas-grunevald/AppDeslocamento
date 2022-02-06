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
    public class GetClientesQuery : IRequest<List<Cliente>>
    {
    }

    public class GetClientesQueryHandler :
        IRequestHandler<GetClientesQuery, List<Cliente>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> Handle(
            GetClientesQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            var clientes = await repositoryCliente
                .GetAll()
                .ToListAsync(cancellationToken);

            return clientes;
        }
    }
}
