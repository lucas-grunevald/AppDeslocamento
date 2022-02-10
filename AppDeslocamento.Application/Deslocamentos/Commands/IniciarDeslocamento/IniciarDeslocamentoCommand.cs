using AppDeslocamento.Application.Carros.Queries;
using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Deslocamentos.Commands
{
    public class IniciarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }

        public long ClienteId { get; set; }

        public long CondutorId { get; set; }

        public long QuilometragemInicial { get; set; }

    }

    public class CriarDeslocamentoCommandHandler : IRequestHandler<IniciarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(IniciarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento =  await repository
                .FindBy(d => d.CarroId == request.CarroId && d.CondutorId == request.CondutorId && d.ClienteId == request.ClienteId && d.QuilometragemFinal == null)                
                .FirstAsync();            

            deslocamento.IniciarDeslocamento(request.CarroId, request.ClienteId, request.CondutorId, DateTime.Now.ToUniversalTime(), request.QuilometragemInicial);

            repository.Add(deslocamento);

            await _unitOfWork.CommitAsync();

            return deslocamento;
        }
    }
}
