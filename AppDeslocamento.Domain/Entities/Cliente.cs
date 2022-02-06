using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(String cpf,String nome)
        {
            Cpf = cpf;
            Nome = nome;
        }

        private Cliente() { }

        public String Cpf { get; private set; }

        public String Nome { get; private set; }

        private readonly List<Deslocamento> _deslocamentos = new();

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
    }
}
