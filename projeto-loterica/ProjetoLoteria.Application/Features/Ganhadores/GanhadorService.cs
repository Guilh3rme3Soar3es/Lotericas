using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using ProjetoLoterica.Domain.Features.Ganhadores;
using ProjetoLoterica.Domain.Exceptions;

namespace ProjetoLoteria.Application.Features.Ganhadores
{
    public class GanhadorService : IGanhadorService
    {
        private IGanhadorRepository _repository;

        public GanhadorService(IGanhadorRepository repository)
        {
            _repository = repository;
        }
        public Ganhador Add(Ganhador ganhador)
        {
            ganhador.Validate();
            return _repository.Save(ganhador);
        }

        public void Delete(Ganhador ganhador)
        {
            if (ganhador.id <= 0)
                throw new IdentifierUndefinedException();
            _repository.Delete(ganhador);
        }

        public Ganhador Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Ganhador> GetAll()
        {
            return _repository.GetAll();
        }

        public Ganhador Update(Ganhador ganhador)
        {
            if (ganhador.id <= 0)
                throw new IdentifierUndefinedException();
            ganhador.Validate();
            return _repository.Update(ganhador);
        }
    }
}
