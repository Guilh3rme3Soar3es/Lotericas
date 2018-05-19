using ProjetoLoterica.Domain.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Application.Features.Resultados
{
    public interface IResultadoService
    {
        Resultado Add(Resultado resultado);
        Resultado Update(Resultado resultado);
        Resultado Get(long id);
        IEnumerable<Resultado> GetAll();
        void Delete(Resultado resultado);
    }
}
