using ProjetoLoterica.Domain.Features.Apostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Application.Features.Apostas
{
    public interface IApostaService
    {
        Aposta Add(Aposta aposta);
        Aposta Update(Aposta aposta);
        Aposta Get(long id);
        IEnumerable<Aposta> GetAll();
        void Delete(Aposta aposta);
    }
}
