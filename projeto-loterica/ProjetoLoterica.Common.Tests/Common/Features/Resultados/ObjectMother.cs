using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using ProjetoLoterica.Domain.Features.Concursos;
using ProjetoLoterica.Domain.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Common.Tests.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Resultado GetResultado(Concurso concurso)
        {
            return new Resultado()
            {
                _Concurso = concurso,
                _ValorQuadra = 0,
                _ValorQuina = 0,
                _ValorSena = 0,
                _Resultado = new List<Dezena>()
            };
        } 

        public static Resultado GetResultadoOk(Concurso concurso, List<Ganhador> listGanhadores)
        {
            return new Resultado()
            {
                _Concurso = concurso,
                _ValorQuadra = 0,
                _ValorQuina = 0,
                _ValorSena = 0,
                _Resultado = new List<Dezena>(),
                _Ganhadores = listGanhadores
            };
        }
    }
}
