using ProjetoLoterica.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Boloes
{
    public class BolaoNoAmountOfBetsException : BusinessException
    {
        public BolaoNoAmountOfBetsException() : base("O bolão deve conter uma quantidade de apostas maior que 0.")
        {
        }
    }
}
