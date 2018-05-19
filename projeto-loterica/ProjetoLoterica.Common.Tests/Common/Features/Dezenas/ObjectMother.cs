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

        public static Dezena GetDezenas(Aposta aposta = null)
        {
            Dezena dezena = new Dezena { _Dezena = 20, _Aposta = aposta };

            return dezena;
        }


        public static List<Dezena> GetListDezenas(Aposta aposta)
        {
            return new List<Dezena>()
            {
                new Dezena() {_Dezena = 1, _Aposta = aposta},
                new Dezena() {_Dezena = 2, _Aposta = aposta},
                new Dezena() {_Dezena = 3, _Aposta = aposta},
                new Dezena() {_Dezena = 4, _Aposta = aposta},
                new Dezena() {_Dezena = 5, _Aposta = aposta},
                new Dezena() {_Dezena = 6, _Aposta = aposta}
            };
        }
    }
}
