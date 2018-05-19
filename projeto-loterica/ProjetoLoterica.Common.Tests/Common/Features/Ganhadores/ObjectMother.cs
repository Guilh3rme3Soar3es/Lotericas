using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Common.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Ganhador GetGanhador(Aposta aposta, Concurso concurso)
        {
            return new Ganhador
            {
                _TipoPremio = Ganhador.TipoPremio.SENA,
                _ValorPremio = 100,
                Concurso = concurso,
                Aposta = aposta
            };
        } 
    }
}
