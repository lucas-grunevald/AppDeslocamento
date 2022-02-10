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
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {
        
    }

    public class GetDeslocamentosQueryHandler : IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamento>> Handle(
             GetDeslocamentosQuery request,
             CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamentos = await repository
                .GetAll()
                .ToListAsync(cancellationToken);

            return deslocamentos;
        }
    }
}
