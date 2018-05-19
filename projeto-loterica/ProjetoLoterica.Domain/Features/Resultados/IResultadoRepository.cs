using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Resultados
{
    public interface IResultadoRepository
    {
        Resultado Save(Resultado resultado);
        Resultado Update(Resultado resultado);
        Resultado Get(long id);
        IEnumerable<Resultado> GetAll();
        void Delete(Resultado resultado);
    }
}
