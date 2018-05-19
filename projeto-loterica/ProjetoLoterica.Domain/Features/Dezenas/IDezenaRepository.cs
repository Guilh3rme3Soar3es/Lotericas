using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Dezenas
{
    public interface IDezenaRepository
    {
        Dezena Save(Dezena dezena);
        Dezena Update(Dezena dezena);
        Dezena Get(long id);
        IEnumerable<Dezena> GetAll();
        void Delete(Dezena dezena);
    }
}
