using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Common
{
    public abstract class Entity
    {
        public long id;

        public abstract void Validate();
    }
}
