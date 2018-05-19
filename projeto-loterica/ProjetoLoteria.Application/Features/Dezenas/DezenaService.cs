using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Dezenas;
using ProjetoLoterica.Domain.Exceptions;

namespace ProjetoLoteria.Application.Features.Dezenas
{
    public class DezenaService : IDezenasService
    {
        private IDezenaRepository _repository;

        public DezenaService(IDezenaRepository repository)
        {
            _repository = repository;
        }
        public Dezena Add(Dezena dezena)
        {
            dezena.Validate();
            return _repository.Save(dezena);
        }

        public void Delete(Dezena dezena)
        {
            if (dezena.id <= 0)
                throw new IdentifierUndefinedException();
            _repository.Delete(dezena);
        }

        public Dezena Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Dezena> GetAll()
        {
            return _repository.GetAll();
        }

        public Dezena Update(Dezena dezena)
        {
            if (dezena.id <= 0)
                throw new IdentifierUndefinedException();
            dezena.Validate();
            return _repository.Update(dezena);
        }
    }
}
