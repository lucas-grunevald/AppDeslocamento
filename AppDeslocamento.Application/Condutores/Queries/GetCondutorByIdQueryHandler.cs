using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Condutores.Queries
{
    public class GetCondutorByIdQuery : IRequest<Condutor>
    {
        public long condutorId { get; set; }
    }

    public class GetCondutorByIdQueryHandler : IRequestHandler<GetCondutorByIdQuery, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(
            GetCondutorByIdQuery request,
            CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Condutor>();

            var condutor = await repository
                .GetByIdAsync(request.condutorId);

            return condutor;
        }
    }
}
