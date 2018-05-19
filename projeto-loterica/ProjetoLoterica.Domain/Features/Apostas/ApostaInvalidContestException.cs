using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas
{
    public class ApostaInvalidContestException : BusinessException

    {
        public ApostaInvalidContestException() : base("Aposta não está ligada ao concurso!")
        {
        }
    }
}
