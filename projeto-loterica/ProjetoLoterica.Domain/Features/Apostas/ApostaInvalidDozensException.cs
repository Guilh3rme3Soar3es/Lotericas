using ProjetoLoterica.Domain.Exceptions;

namespace ProjetoLoterica.Domain.Features.Apostas
{
    public class ApostaInvalidDozensException : BusinessException
    {
        public ApostaInvalidDozensException( ) : base("Dezenas da Aposta estão inválidas")
        {
        }
    }
}