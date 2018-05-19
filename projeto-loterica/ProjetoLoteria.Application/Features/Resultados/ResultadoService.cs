using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLoterica.Domain.Features.Resultados;

namespace ProjetoLoteria.Application.Features.Resultados
{
    public class ResultadoService : IResultadoService
    {
        private IResultadoRepository _repository;

        public ResultadoService(IResultadoRepository repository)
        {
            _repository = repository;
        }
        public Resultado Add(Resultado resultado)
        {
            throw new NotImplementedException();
        }

        public void Delete(Resultado resultado)
        {
            throw new NotImplementedException();
        }

        public Resultado Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resultado> GetAll()
        {
            throw new NotImplementedException();
        }

        public Resultado Update(Resultado resultado)
        {
            throw new NotImplementedException();
        }
    }
}
