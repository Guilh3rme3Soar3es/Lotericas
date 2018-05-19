using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Resultados
{
    public class ResultadoConcursoNullException : BusinessException
    {
        public ResultadoConcursoNullException() : base("O resultado deve conter um bolão.")
        {
        }
    }
}
