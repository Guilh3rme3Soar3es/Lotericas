using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Concursos
{
    public interface IConcursoRepository
    {
        Concurso Save(Concurso aposta);
        Concurso Update(Concurso aposta);
        Concurso Get(long id);
        IEnumerable<Concurso> GetAll();
        void Delete(Concurso aposta);
    }
}
