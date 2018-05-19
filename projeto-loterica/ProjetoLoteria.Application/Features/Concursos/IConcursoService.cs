using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Application.Features.Concursos
{
    public interface IConcursoService
    {
        Concurso Add(Concurso concurso);
        Concurso Update(Concurso concurso);
        Concurso Get(long id);
        IEnumerable<Concurso> GetAll();
        void Delete(Concurso concurso);
    }
}
