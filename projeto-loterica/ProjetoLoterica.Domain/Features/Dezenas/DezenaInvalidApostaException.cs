using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas.Dezenas
{
    public class DezenaInvalidApostaException : BusinessException
    {
        public DezenaInvalidApostaException() : base("Dezena com aposta inválida")
        {
        }
    }
}
