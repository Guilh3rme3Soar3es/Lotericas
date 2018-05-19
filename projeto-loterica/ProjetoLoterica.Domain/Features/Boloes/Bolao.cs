using ProjetoLoterica.Domain.Common;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Boloes
{
    public class Bolao : Entity
    {
        private Random rnd = new Random();

        public int QtdApostas { get; set; }
        public double _ValorTotal { get; set; }
        public List<Aposta> _Aposta { get; set; }

        public override void Validate()
        {
            if (_Aposta == null)
                throw new BolaoListNullException();
            if (_Aposta.Count < 1)
                throw new BolaoListApostasEmptyException();
            if (QtdApostas <= 0)
                throw new BolaoNoAmountOfBetsException();
        }

        public void GetValorTotal()
        {
            foreach (var item in _Aposta)
            {
                _ValorTotal += item.Valor;
            }
        }

        public Bolao GerarBolao(int QtdApostas)
        {
            return new Bolao()
            {
                QtdApostas = QtdApostas,
                _Aposta = _Aposta
            };

        }

        public void GerarApostas(int QtdApostas, Concurso concurso)
        {
            List<Aposta> apostas = new List<Aposta>();
            Bolao bolao = GerarBolao(QtdApostas);

            for (int i = 0; i < QtdApostas; i++)
            {
                apostas.Add(new Aposta { _Bolao = bolao, _Dezenas = GerarDezenas(), _Concurso = concurso });

            }
            _Aposta = apostas.ToList();
        }

        public List<Dezena> GerarDezenas()
        {
            List<int> dezenasOrdenadas = new List<int>();
            List<Dezena> dezenasAposta = new List<Dezena>(); 
            HashSet<int> dezenas = new HashSet<int>();

            do
            {
                dezenas.Add(rnd.Next(1, 60));
            } while (dezenas.Count < 6);

            dezenasOrdenadas = dezenas.ToList();
            dezenasOrdenadas.Sort();

            foreach (var item in dezenasOrdenadas)
            {
                dezenasAposta.Add (new Dezena {_Dezena = item });
            }

            return dezenasAposta;
        }
    }
}

