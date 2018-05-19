using ProjetoLoterica.Domain.Common;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Domain.Features.Resultados
{
    public class Resultado : Entity
    {
        public Concurso _Concurso { get; set; }
        public List<Dezena> _Resultado { get; set; }
        public double _ValorTotal { get; set; }
        public double _ValorSena { get; set; }
        public double _ValorQuina { get; set; }
        public double _ValorQuadra { get; set; }
        public double _ValorLoterica { get; set; }
        public List<Ganhador> _Ganhadores { get; set; }

        //Podemos ter 3 atributos aqui...
        //...
        public int GanhadoresQuadra { get; set; }
        public int GanhadoresQuina { get; set; }
        public int GanhadoresSena { get; set; }
        //...
        //QUE FARIA COM QUE PUDESSEMOS DIVIDIR AS PRIMIAÇÕES EM METODOS...

        public Resultado()
        {
            if (_Ganhadores == null)
                _Ganhadores = new List<Ganhador>();
        }
        public override void Validate()
        {
            if (_Concurso == null)
                throw new ResultadoConcursoNullException();
        }

        public void GetValorTotal()
        {
            foreach (var item in _Concurso._Apostas)
                _ValorTotal = item.Valor;
        }

        public void GetValorLoterica()
        {
            _ValorTotal = _ValorTotal - (_ValorTotal * 0.1);
            _ValorLoterica = _ValorTotal * 0.1;
        }

        public List<Dezena> FecharConcurso_GerarResultado()
        {
            Random rnd = new Random();
            List<int> dezenasOrdenadas = new List<int>();
            List<Dezena> resultado = new List<Dezena>();
            HashSet<int> dezenas = new HashSet<int>();

            do
            {
                dezenas.Add(rnd.Next(1, 60));
            } while (dezenas.Count < 6);

            dezenasOrdenadas = dezenas.ToList();
            dezenasOrdenadas.Sort();

            foreach (var item in dezenas)
            {
                resultado.Add(new Dezena { _Dezena = item });
            }

            return resultado;
        }

        // Verificar...
        public void VerificarListAposta()
        {
            for (int i = 0; i < _Concurso._Apostas.Count; i++)
            {
                VerificarAposta(_Concurso._Apostas[i]);
            }
        }

        public void VerificarAposta(Aposta aposta)
        {
            int dezenasAcertadas = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (_Resultado[i] == aposta._Dezenas[j])
                    {
                        dezenasAcertadas++;
                    }
                }
            }
            if (dezenasAcertadas == 4)
                _Ganhadores.Add(new Ganhador { Aposta = aposta, _TipoPremio = Ganhador.TipoPremio.QUADRA });

            if (dezenasAcertadas == 5)
                _Ganhadores.Add(new Ganhador { Aposta = aposta, _TipoPremio = Ganhador.TipoPremio.QUINA });

            if (dezenasAcertadas == 6)
                _Ganhadores.Add(new Ganhador { Aposta = aposta, _TipoPremio = Ganhador.TipoPremio.SENA });
        }

        

        //Verificar...
        public void VerificaTipoPremio()
        {
            GetValorTotal();
            GetValorLoterica();

            foreach (var item in _Ganhadores)
            {
                if (item._TipoPremio == Ganhador.TipoPremio.QUADRA)
                    GanhadoresQuadra++;
                if (item._TipoPremio == Ganhador.TipoPremio.QUINA)
                    GanhadoresQuina++;
                if (item._TipoPremio == Ganhador.TipoPremio.SENA)
                    GanhadoresSena++;
            }
            PremiarQuadra();
        }

        public void PremiarQuadra()
        {
            if (GanhadoresQuadra > 0)
            {
                DividirPremios(0.1, 0.2, 0.7);

                foreach (var item in _Ganhadores)
                {
                    if (item._TipoPremio == Ganhador.TipoPremio.QUADRA)
                        item._ValorPremio = _ValorQuadra / GanhadoresQuadra;

                    if (item._TipoPremio == Ganhador.TipoPremio.QUINA)
                            item._ValorPremio = _ValorQuina / GanhadoresQuina;
                    if (item._TipoPremio == Ganhador.TipoPremio.SENA)
                    {
                        item._ValorPremio = _ValorSena / GanhadoresSena;
                        if (GanhadoresQuina <= 0)
                            item._ValorPremio += _ValorQuina / GanhadoresSena;
                    }
                            
                }
            }
            else
                PremiarQuina();
        }

        public void PremiarQuina()
        {
            if (GanhadoresQuina > 0)
            {
                DividirPremios(0, 0.25, 0.75);

                foreach (var item in _Ganhadores)
                {
                    if (item._TipoPremio == Ganhador.TipoPremio.QUINA)
                        item._ValorPremio = _ValorQuina / GanhadoresQuina;

                    if (item._TipoPremio == Ganhador.TipoPremio.SENA)
                        item._ValorPremio = _ValorSena / GanhadoresSena;
                }
            }
            else
                PremiarSena();
        }

        public void PremiarSena()
        {
            if (GanhadoresSena > 0)
            {
                DividirPremios(0,0,1);

                foreach (var item in _Ganhadores)
                {
                    if (item._TipoPremio == Ganhador.TipoPremio.SENA)
                        item._ValorPremio = _ValorSena / GanhadoresSena;
                }
            }
        }

        public void DividirPremios(double quadra, double quina, double sena)
        {
                _ValorQuadra = _ValorTotal * quadra;
                _ValorQuina = _ValorTotal * quina;
                _ValorSena = _ValorTotal * sena;
        }






        //Verificar...
        //public void Premiar()
        //{
        //    GetValorTotal();
        //    GetValorLoterica();

        //    var ganhadoresQuadra = 0;
        //    var ganhadoresQuina = 0;
        //    var ganhadoresSena = 0;

        //    foreach (var item in _Ganhadores)
        //    {
        //        if (item._TipoPremio == Ganhador.TipoPremio.QUADRA)
        //            ganhadoresQuadra++;
        //        if (item._TipoPremio == Ganhador.TipoPremio.QUINA)
        //            ganhadoresQuina++;
        //        if (item._TipoPremio == Ganhador.TipoPremio.SENA)
        //            ganhadoresSena++;
        //    }
        //    if (ganhadoresQuadra > 0)
        //    {
        //        _ValorQuadra = _ValorTotal * 0.1;
        //        _ValorTotal = _ValorTotal - (_ValorTotal * 0.1);

        //        _ValorQuina = _ValorTotal * 0.2;
        //        _ValorTotal = _ValorTotal - (_ValorTotal * 0.2);

        //        _ValorSena = _ValorTotal * 0.7;
        //        _ValorTotal = _ValorTotal - (_ValorTotal * 0.7);

        //        foreach (var item in _Ganhadores)
        //        {
        //            if (item._TipoPremio == Ganhador.TipoPremio.QUADRA)
        //                item._ValorPremio = _ValorQuadra / ganhadoresQuadra;

        //            if (item._TipoPremio == Ganhador.TipoPremio.QUINA)
        //                item._ValorPremio = _ValorQuina / ganhadoresQuina;

        //            if (item._TipoPremio == Ganhador.TipoPremio.SENA)
        //                item._ValorPremio = _ValorSena / ganhadoresSena;
        //        }
        //    }
        //    else if (ganhadoresQuina > 0)
        //    {
        //        _ValorQuina = _ValorTotal * 0.25;
        //        _ValorTotal = _ValorTotal - (_ValorTotal * 0.25);

        //        _ValorSena = _ValorTotal * 0.75;
        //        _ValorTotal = _ValorTotal - (_ValorTotal * 0.75);

        //        foreach (var item in _Ganhadores)
        //        {
        //            if (item._TipoPremio == Ganhador.TipoPremio.QUINA)
        //                item._ValorPremio = _ValorQuadra / ganhadoresQuina;

        //            if (item._TipoPremio == Ganhador.TipoPremio.SENA)
        //                item._ValorPremio = _ValorSena / ganhadoresSena;
        //        }
        //    }
        //    else
        //    {
        //        _ValorSena = _ValorTotal;
        //        _ValorTotal = 0;

        //        foreach (var item in _Ganhadores)
        //        {
        //            if (item._TipoPremio == Ganhador.TipoPremio.SENA)
        //                item._ValorPremio = _ValorSena / ganhadoresSena;
        //        }
        //    }
        //}


        //foi comentado...


        //public void GetValorQuadra()
        //{
        //    GetValorTotal();
        //    GetValorLoterica();
        //    _ValorQuadra = _ValorTotal -
        //}
    }


}
