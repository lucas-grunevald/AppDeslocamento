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
    public class FinalizarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long Id { get; set; }

        public long QuilometragemFinal { get; set; }

        public string Observacao { get; set; }
    }

    public class FinalizarDeslocamentoCommandHandler : IRequestHandler<FinalizarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinalizarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async public Task<Deslocamento> Handle(FinalizarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            
            var repository = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repository.GetByIdAsync(request.Id);            

            deslocamento.FinalizarDeslocamento(request.Observacao, request.QuilometragemFinal);

            repository.Update(deslocamento);

            await _unitOfWork.CommitAsync();

            return deslocamento;
        }
    }
}
