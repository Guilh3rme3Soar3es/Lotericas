using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Boloes
{
    public class BolaoListApostasEmptyException : BusinessException
    {
        public BolaoListApostasEmptyException() : base("O bolão deve conter pelo menos uma mensagem.")
        {
        }
    }
}
