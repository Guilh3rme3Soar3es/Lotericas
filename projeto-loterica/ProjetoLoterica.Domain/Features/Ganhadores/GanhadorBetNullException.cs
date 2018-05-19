using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Ganhadores
{
    public class GanhadorBetNullException : BusinessException
    {
        public GanhadorBetNullException() : base("O ganhador deve conter a sua aposta ganhadora.")
        {
        }
    }
}
