using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Exceptions;

namespace ProjetoLoteria.Application.Features.Apostas
{
    public class ApostaService : IApostaService
    {
        private IApostaRepository _repository;
        public ApostaService(IApostaRepository repository)
        {
            _repository = repository;
        }
        public Aposta Add(Aposta aposta)
        {
            aposta.Validate();
            return _repository.Save(aposta);
        }

        public void Delete(Aposta aposta)
        {
            if (aposta.id <= 0)
                throw new IdentifierUndefinedException();
            _repository.Delete(aposta);
        }

        public Aposta Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Aposta> GetAll()
        {
            return _repository.GetAll();
        }

        public Aposta Update(Aposta aposta)
        {
            if (aposta.id <= 0)
                throw new IdentifierUndefinedException();

            aposta.Validate();
            return _repository.Update(aposta);
        }
    }
}
