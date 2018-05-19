using ProjetoLoterica.Domain.Features.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Application.Features.Boloes
{
    public interface IBolaoService
    {
        Bolao Add(Bolao bolao);
        Bolao Update(Bolao bolao);
        Bolao Get(long id);
        IEnumerable<Bolao> GetAll();
        void Delete(Bolao bolao);
    }
}
