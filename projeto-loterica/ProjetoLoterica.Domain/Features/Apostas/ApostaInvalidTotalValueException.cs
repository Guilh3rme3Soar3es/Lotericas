using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas
{
    public class ApostaInvalidTotalValueException : BusinessException
    {
        public ApostaInvalidTotalValueException() : base("O valor total da aposta deve ser 5% maior que o valor")
        {
        }
    }
}
