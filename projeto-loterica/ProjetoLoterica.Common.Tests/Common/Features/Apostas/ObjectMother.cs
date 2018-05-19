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

        public static Aposta GetAposta(Bolao bolao,Concurso concurso)
        {
            return new Aposta
            {
                id = 2,
                Valor = 3,
                ValorTotal = 3.50,
                _Dezenas = new List<Dezena>(),
                _Bolao = bolao,
                _Concurso = concurso
            };
        }
    }
}
