using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoterica.Domain.Features.Concursos;
using ProjetoLoterica.Domain.Exceptions;

namespace ProjetoLoteria.Application.Features.Concursos
{
    public class ConcursoService : IConcursoService
    {
        private IConcursoRepository _repository;

        public ConcursoService(IConcursoRepository repository)
        {
            _repository = repository;
        }
        public Concurso Add(Concurso concurso)
        {
            concurso.Validate();
            return _repository.Save(concurso);
        }

        public void Delete(Concurso concurso)
        {
            if (concurso.id <= 0)
                throw new IdentifierUndefinedException();
            _repository.Delete(concurso);
        }

        public Concurso Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Concurso> GetAll()
        {
            return _repository.GetAll();
        }

        public Concurso Update(Concurso concurso)
        {
            if (concurso.id <= 0)
                throw new IdentifierUndefinedException();
            concurso.Validate();
            return _repository.Update(concurso);
        }
    }
}
