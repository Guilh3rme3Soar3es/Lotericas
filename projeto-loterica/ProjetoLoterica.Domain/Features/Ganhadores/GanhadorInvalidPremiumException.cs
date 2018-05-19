using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Ganhadores
{
    public class GanhadorInvalidPremiumException : BusinessException
    {
        public GanhadorInvalidPremiumException() : base("O valor do premio deve ser maior ou igual a zero")
        {
        }
    }
}
