using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Apostas
{
    public interface IApostaRepository
    {
        Aposta Save(Aposta aposta);
        Aposta Update(Aposta aposta);
        Aposta Get(long id);
        IEnumerable<Aposta> GetAll();
        void Delete(Aposta aposta);
    }
}
