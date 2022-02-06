using AppDeslocamento.Application.Carros.Queries;
using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class CriarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }

        public long ClienteId { get; set; }

        public long CondutorId { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public long QuilometragemInicial { get; set; }

        public string Observacao { get; set; }
    }

    public class CriarDeslocamentoCommandHandler : IRequestHandler<CriarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(CriarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var insertDeslocamento = new Deslocamento(request.CarroId, request.ClienteId, request.CondutorId, request.DataHoraInicio, request.QuilometragemInicial, request.Observacao);

            var carros = await new GetCarrosQueryHandler(_unitOfWork).Handle(new GetCarrosQuery(), cancellationToken);
            
            if(carros.Count > 0)
            {
                return null;
            }

            var repository = _unitOfWork.GetRepository<Deslocamento>();

            repository.Add(insertDeslocamento);

            await _unitOfWork.CommitAsync();

            return insertDeslocamento;

        }
    }
}
