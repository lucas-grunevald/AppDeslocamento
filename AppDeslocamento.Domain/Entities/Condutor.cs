using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Condutor : BaseEntity
    {
        public Condutor(String nome, String email)
        {
            Nome = nome;
            Email = email;
        }

        private Condutor()
        { }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        private readonly List<Deslocamento> _deslocamentos = new();

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();
    }
}
