using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Concursos
{
    public class ConcursoInvalidBetsException : BusinessException
    {
        public ConcursoInvalidBetsException() : base("Concurso sem apostas")
        {
        }
    }
}
