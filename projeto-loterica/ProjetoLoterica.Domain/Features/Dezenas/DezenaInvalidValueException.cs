using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas.Dezenas
{
    public class DezenaInvalidValueException : BusinessException
    {
        public DezenaInvalidValueException() : base("Dezena Inválida!")
        {
        }
    }
}
