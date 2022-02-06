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
    public class GetCondutoresQuery : IRequest<List<Condutor>>
    {
    }

    public class GetCondutoresQueryHandler : IRequestHandler<GetCondutoresQuery, List<Condutor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutoresQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Condutor>> Handle(
            GetCondutoresQuery request,
            CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Condutor>();

            var condutores = await repository
                .GetAll()
                .ToListAsync(cancellationToken);

            return condutores;
        }
    }
}
