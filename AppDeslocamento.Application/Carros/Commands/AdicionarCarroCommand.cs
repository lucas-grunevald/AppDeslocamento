using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Carros.Commands
{
    public class AdicionarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }
    }

    public class AdicionarCarroCommandHandler : IRequestHandler<AdicionarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(AdicionarCarroCommand request, CancellationToken cancellationToken)
        {
            var insertCarro = new Carro(request.Placa, request.Descricao);

            var repository = _unitOfWork.GetRepository<Carro>();

            repository.Add(insertCarro);

            await _unitOfWork.CommitAsync();

            return insertCarro;
        }
    }
}
