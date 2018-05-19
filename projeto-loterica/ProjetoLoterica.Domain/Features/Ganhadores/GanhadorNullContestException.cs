using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Ganhadores
{
    public class GanhadorNullContestException : BusinessException
    {
        public GanhadorNullContestException() : base("Um ganhador deve conter um concurso.")
        {
        }
    }
}
