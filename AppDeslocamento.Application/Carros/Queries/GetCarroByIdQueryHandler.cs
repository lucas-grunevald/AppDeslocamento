using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Carros.Queries
{
    public class GetCarroByIdQuery : IRequest<Carro>
    {
        public long carroId { get; set; }
    }

    public class GetCarroByIdQueryHandler : IRequestHandler<GetCarroByIdQuery, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarroByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(
            GetCarroByIdQuery request,
            CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Carro>();

            var carro = await repository
                .GetByIdAsync(request.carroId);

            return carro;
        }
    }
}
