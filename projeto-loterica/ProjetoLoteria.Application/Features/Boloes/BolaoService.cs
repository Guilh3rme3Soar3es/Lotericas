using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoterica.Domain.Exceptions;
using ProjetoLoterica.Domain.Features.Boloes;

namespace ProjetoLoteria.Application.Features.Boloes
{
    public class BolaoService : IBolaoService
    {
        private IBolaoRepository _repository;

        public BolaoService(IBolaoRepository repository)
        {
            _repository = repository;
        }

        public Bolao Add(Bolao bolao)
        {
            bolao.Validate();
            return _repository.Save(bolao);
        }

        public void Delete(Bolao bolao)
        {
            if (bolao.id <= 0)
                throw new IdentifierUndefinedException();
            _repository.Delete(bolao);
        }

        public Bolao Get(long id)
        {
            if (id <= 0)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Bolao> GetAll()
        {
            return _repository.GetAll();
        }

        public Bolao Update(Bolao bolao)
        {
            if (bolao.id <= 0)
                throw new IdentifierUndefinedException();

            bolao.Validate();
            return _repository.Update(bolao);
        }
    }
}
