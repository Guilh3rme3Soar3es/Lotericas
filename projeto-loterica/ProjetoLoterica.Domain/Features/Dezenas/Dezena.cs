using ProjetoLoterica.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas.Dezenas
{
    public class Dezena : Entity
    {
        public virtual int _Dezena { get; set; }
        public virtual Aposta _Aposta { get; set; }


        public override void Validate()
        {
            if(_Dezena <= 0 || _Dezena > 60)
            {
                throw new DezenaInvalidValueException();
            }
            //Não necessariamente uma dezena e de uma aposta..
            //if(_Aposta == null)
            //{
            //    throw new DezenaInvalidApostaException();
            //}
            
        }
    }
}
