using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Boloes
{
    public interface IBolaoRepository
    {
        Bolao Save(Bolao bolao);
        Bolao Update(Bolao bolao);
        Bolao Get(long id);
        IEnumerable<Bolao> GetAll();
        void Delete(Bolao bolao);
    }
}
