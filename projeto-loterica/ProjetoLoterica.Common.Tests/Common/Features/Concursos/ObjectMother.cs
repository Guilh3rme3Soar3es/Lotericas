using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Boloes;
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

        public static Concurso GetConcurso(List<Aposta> listAposta = null)
        {
            Concurso concurso = new Concurso();
            concurso._Numero = 10;
            concurso._Apostas= listAposta;

            return concurso;
        }
    }
}
