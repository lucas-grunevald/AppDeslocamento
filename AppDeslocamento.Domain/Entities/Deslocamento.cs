using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {

        public Deslocamento() { }

        public long CarroId { get; private set; }

        public long ClienteId { get; private set; }

        public long CondutorId { get; private set; }

        public DateTime DataHoraInicio { get; private set; }

        public long QuilometragemInicial { get; private set; }

        public string Observacao { get; private set; }

        public DateTime? DataHoraFim { get; private set; }

        public long? QuilometragemFinal { get; private set; }

        public Carro Carro { get; private set; }

        public Condutor Condutor { get; private set; }

        public Cliente Cliente { get; private set; }

        public Deslocamento IniciarDeslocamento(long carroId, long clienteId, long condutorId, DateTime dataHoraInicio, long quilometragemInicial)
        {
            var deslocamento = new Deslocamento();

            deslocamento.CarroId = carroId;
            deslocamento.ClienteId = clienteId;
            deslocamento.CondutorId = condutorId;
            deslocamento.DataHoraInicio = dataHoraInicio;
            deslocamento.QuilometragemInicial = quilometragemInicial;
            deslocamento.Observacao = "";

            return deslocamento;
        }

        public void FinalizarDeslocamento( string observacao, long quilometragemFinal)
        {            
            DataHoraFim = DateTime.Now;
            Observacao = observacao;
            QuilometragemFinal = quilometragemFinal;
        }

    }
}
