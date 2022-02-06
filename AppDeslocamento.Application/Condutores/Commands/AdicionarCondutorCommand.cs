using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Condutores.Commands
{
    public class AdicionarCondutorCommand : IRequest<Condutor>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class AdicionarCondutorCommandHandler : IRequestHandler<AdicionarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(AdicionarCondutorCommand request, CancellationToken cancellationToken)
        {
            var insertCondutor = new Condutor(request.Nome, request.Email);

            var repository = _unitOfWork.GetRepository<Condutor>();

            repository.Add(insertCondutor);

            await _unitOfWork.CommitAsync();

            return insertCondutor;
        }
    }
}
