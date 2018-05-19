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

        public static Bolao GetBolao(List<Aposta> listAposta)
        {
            Bolao bolao = new Bolao();
            bolao._Aposta = listAposta;

            return bolao;
        }

        public static Bolao GetBolaoSemLista()
        {
            return new Bolao
            {
                QtdApostas = 1,
                _Aposta = null
            };
        }

        public static Bolao GetBolaoOk(List<Aposta> listAposta)
        {
            return new Bolao
            {
                QtdApostas = 1,
                _ValorTotal = 3,
                _Aposta = listAposta
            };
        }
    }
}
