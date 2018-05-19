using ProjetoLoterica.Domain.Common;
using ProjetoLoterica.Domain.Features.Concursos;
using ProjetoLoterica.Domain.Features.Ganhadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas.Ganhadores
{
    public class Ganhador : Entity
    {
        public enum TipoPremio
        {
            SEMPREMIACAO,
            QUADRA,
            QUINA,
            SENA
        };

        public Concurso Concurso;
        public Aposta Aposta;
        public virtual TipoPremio _TipoPremio { get; set; }

        //comentar sobre...
        public double _ValorPremio;

        public override void Validate()
        {
            if (Concurso == null)
                throw new GanhadorNullContestException();
            if (Aposta == null)
                throw new GanhadorBetNullException();
            if (_ValorPremio < 0)
                throw new GanhadorInvalidPremiumException();
        }
    }
}
