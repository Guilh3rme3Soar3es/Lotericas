using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas
{
    public class ApostaInvalidValueException : BusinessException
    {
        public ApostaInvalidValueException() : base("O valor da aposta deve ser maior que 0")
        {
        }
    }
}
