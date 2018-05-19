using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Ganhadores
{
    public interface IGanhadorRepository
    {
        Ganhador Save(Ganhador ganhador);
        Ganhador Update(Ganhador ganhador);
        Ganhador Get(long id);
        IEnumerable<Ganhador> GetAll();
        void Delete(Ganhador ganhador);
    }
}
