using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Boloes
{
    public class BolaoListNullException : BusinessException
    {
        public BolaoListNullException() : base("A lista de apostas não deve ser nula.")
        {
        }
    }
}
