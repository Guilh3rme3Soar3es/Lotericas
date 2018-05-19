using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Concursos
{
    public class ConcursoInvalidNumberException : BusinessException
    {
        public ConcursoInvalidNumberException() : base("Número do concurso está inválido")
        {
        }
    }
}
