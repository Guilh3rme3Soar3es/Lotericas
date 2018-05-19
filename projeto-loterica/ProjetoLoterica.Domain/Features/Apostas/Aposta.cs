using ProjetoLoterica.Domain.Common;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Boloes;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas
{
    public class Aposta : Entity
    {
        public virtual Concurso _Concurso { get; set; }
        public virtual double Valor { get; set; }
        public virtual double ValorTotal { get; set; }
        public virtual List<Dezena> _Dezenas { get; set; }
        public virtual Bolao _Bolao { get; set; }

        public Aposta()
        {
            EstaNoBolao();
        }


        public override void Validate()
        {
            if (Valor <= 0)
                throw new ApostaInvalidValueException();
            if (ValorTotal < Valor)
            {
                throw new ApostaInvalidTotalValueException();
            }
            if (_Dezenas.Count != 6)
                throw new ApostaInvalidDozensException();
            if (_Concurso == null)
            {
                throw new ApostaInvalidContestException();
            }
        }

        public void EstaNoBolao()
        {
            if (_Bolao != null)
                ValorTotal = (Valor + (Valor * 0.05));
            else
                ValorTotal = Valor;
        }

        public void GerarValor()
        {
            Valor = _Dezenas.Count * 0.50;
        }


    }
}
