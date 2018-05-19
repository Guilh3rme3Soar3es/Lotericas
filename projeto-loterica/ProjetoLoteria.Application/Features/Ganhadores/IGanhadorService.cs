using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Application.Features.Ganhadores
{
    public interface IGanhadorService
    {
        Ganhador Add(Ganhador ganhador);
        Ganhador Update(Ganhador ganhador);
        Ganhador Get(long id);
        IEnumerable<Ganhador> GetAll();
        void Delete(Ganhador ganhador);
    }
}
