using ProjetoLoterica.Domain.Common;
using ProjetoLoterica.Domain.Features.Apostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Concursos
{
    public class Concurso : Entity
    {
        public long _Numero { get; set; }
        public List<Aposta> _Apostas { get; set; }


        public override void Validate()
        {
            if (_Numero < 1)
            {
                throw new ConcursoInvalidNumberException();
            }
            //if (_Apostas == null)
            //{
            //    throw new ConcursoInvalidBetsException();
            //}


        }
    }
}
