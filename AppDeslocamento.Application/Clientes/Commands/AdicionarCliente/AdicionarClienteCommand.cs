using AppDeslocamento.Domain.Entities;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Application.Clientes.Commands.AdicionarCliente
{
    public class AdicionarClienteCommand : IRequest<Cliente>
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }
    }

    public class AdicionarClienteCommandHandler : IRequestHandler<AdicionarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            var insertCliente = new Cliente(request.Cpf, request.Nome);

            

            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(insertCliente);

            await _unitOfWork.CommitAsync();

            return insertCliente;
        }
    }
}
