using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using ProjetoLoterica.Domain.Features.Concursos;
using ProjetoLoterica.Domain.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Domain.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoDomainTests
    {
        private Mock<Concurso> _concurso;
        private Mock<Aposta> _aposta;

        private Resultado _resultado;
        private List<Aposta> listAposta;
        private List<Dezena> listDezenas;
        private List<Ganhador> listGanhadores;

        private Mock<Ganhador> ganhadorSena;
        private Mock<Ganhador> ganhadorQuina;
        private Mock<Ganhador> ganhadorQuadra;

        private Mock<Dezena> _fakePrimeiraDezena;
        private Mock<Dezena> _fakeSegundaDezena;
        private Mock<Dezena> _fakeTerceiraDezena;
        private Mock<Dezena> _fakeQuartaDezena;
        private Mock<Dezena> _fakeQuintaDezena;
        private Mock<Dezena> _fakeSextaDezena;

        private Mock<Dezena> _fakeSetimaDezena;
        private Mock<Dezena> _fakeOitavaDezena;


        [SetUp]
        public void Initialize()
        {
            ganhadorSena = new Mock<Ganhador>();
            ganhadorQuina = new Mock<Ganhador>();
            ganhadorQuadra = new Mock<Ganhador>();

            listGanhadores = new List<Ganhador>()
            {
                ganhadorSena.Object,
                ganhadorQuina.Object,
                ganhadorQuadra.Object
            };

            _concurso = new Mock<Concurso>();
            _aposta = new Mock<Aposta>();

            _fakePrimeiraDezena = new Mock<Dezena>();
            _fakeSegundaDezena = new Mock<Dezena>();
            _fakeTerceiraDezena = new Mock<Dezena>();
            _fakeQuartaDezena = new Mock<Dezena>();
            _fakeQuintaDezena = new Mock<Dezena>();
            _fakeSextaDezena = new Mock<Dezena>();
            _fakeSetimaDezena = new Mock<Dezena>();
            _fakeOitavaDezena = new Mock<Dezena>();

            _fakePrimeiraDezena.Setup(x => x._Dezena).Returns(1);
            _fakeSegundaDezena.Setup(x => x._Dezena).Returns(2);
            _fakeTerceiraDezena.Setup(x => x._Dezena).Returns(3);
            _fakeQuartaDezena.Setup(x => x._Dezena).Returns(4);
            _fakeQuintaDezena.Setup(x => x._Dezena).Returns(5);
            _fakeSextaDezena.Setup(x => x._Dezena).Returns(6);

            listDezenas = new List<Dezena>() {
                _fakePrimeiraDezena.Object,
                _fakeSegundaDezena.Object,
                _fakeTerceiraDezena.Object,
                _fakeQuartaDezena.Object,
                 _fakeQuintaDezena.Object,
                 _fakeSextaDezena.Object
            };

            _aposta.Setup(m => m._Dezenas).Returns(listDezenas);

            listAposta = new List<Aposta>()
            {
                _aposta.Object
            };

            _resultado = ObjectMother.GetResultado(_concurso.Object);
            _resultado._Resultado = listDezenas;
        }

        [Test]
        public void Resultado_TestDomain_Constuctor_ShouldBeOk()
        {
            _resultado = new Resultado()
            {
                _Ganhadores = null
            };
        }

        [Test]
        public void Resultado_TestDomain_GetResultado_ShouldBeOk()
        {
            _resultado._Resultado = _resultado.FecharConcurso_GerarResultado();

            _resultado._Resultado.Count.Should().Be(6);
        }

        [Order(0)]
        [Test]
        public void Resultado_TestDomain_VerifyBets_Sena_ShouldBeOk()
        {
            _resultado.VerificarAposta(_aposta.Object);

            _resultado._Ganhadores.Count.Should().Be(1);
            _resultado._Ganhadores[0]._TipoPremio.Should().Be(Ganhador.TipoPremio.SENA);
        }

        [Order(1)]
        [Test]
        public void Resultado_TestDomain_VerifyBets_Quina_ShouldBeOk()
        {
            _fakeOitavaDezena.Setup(m => m._Dezena).Returns(8);
            listDezenas = new List<Dezena>() {
                _fakePrimeiraDezena.Object,
                _fakeSegundaDezena.Object,
                _fakeTerceiraDezena.Object,
                _fakeQuartaDezena.Object,
                 _fakeQuintaDezena.Object,
                _fakeOitavaDezena.Object
                };
            _aposta.Setup(m => m._Dezenas).Returns(listDezenas);

            _resultado.VerificarAposta(_aposta.Object);

            _resultado._Ganhadores.Count.Should().Be(1);
            _resultado._Ganhadores[0]._TipoPremio.Should().Be(Ganhador.TipoPremio.QUINA);
        }

        [Order(2)]
        [Test]
        public void Resultado_TestDomain_VerifyBets_Quadra_ShouldBeOk()
        {
            _fakeSetimaDezena.Setup(m => m._Dezena).Returns(7);
            _fakeOitavaDezena.Setup(m => m._Dezena).Returns(8);
            listDezenas = new List<Dezena>() {
                _fakePrimeiraDezena.Object,
                _fakeSegundaDezena.Object,
                _fakeTerceiraDezena.Object,
                _fakeQuartaDezena.Object,
                _fakeSetimaDezena.Object,
                _fakeOitavaDezena.Object
             };
            _aposta.Setup(m => m._Dezenas).Returns(listDezenas);

            _resultado.VerificarAposta(_aposta.Object);

            _resultado._Ganhadores.Count.Should().Be(1);
            _resultado._Ganhadores[0]._TipoPremio.Should().Be(Ganhador.TipoPremio.QUADRA);
        }

        [Test]
        public void Resultado_TestDomain_VerifyWinners_Sena_ShouldBeOk()
        {
            var quantidadeGanhadores = 1;
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SENA);
            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;

            _resultado.VerificaTipoPremio();

            _resultado.GanhadoresSena.Should().Be(quantidadeGanhadores);
        }

        [Test]
        public void Resultado_TestDomain_VerifyWinners_Quina_ShouldBeOk()
        {
            var quantidadeGanhadores = 1;
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUINA);
            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;

            _resultado.VerificaTipoPremio();

            _resultado.GanhadoresQuina.Should().Be(quantidadeGanhadores);
        }

        [Test]
        public void Resultado_TestDomain_VerifyWinners_Quadra_ShouldBeOk()
        {
            var quantidadeGanhadores = 1;
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUADRA);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;

            _resultado.VerificaTipoPremio();

            _resultado.GanhadoresQuadra.Should().Be(quantidadeGanhadores);
        }

        [Test]
        public void Resultado_TestDomain_SharePremium_AllAwarded_ShouldBeOk()
        {
            var valorEsperadoSena = 70;
            var valorEsperadoQuina = 20;
            var valorEsperadoQuadra = 10;

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;

            _resultado.DividirPremios(0.1, 0.2, 0.7);

            _resultado._ValorQuadra.Should().Be(valorEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(valorEsperadoQuina);
            _resultado._ValorSena.Should().Be(valorEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_SharePremium_SenaAndQuinaAwarded_ShouldBeOk()
        {
            var valorEsperadoSena = 75;
            var valorEsperadoQuina = 25;
            var valorEsperadoQuadra = 0;

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;

            _resultado.DividirPremios(0, 0.25, 0.75);

            _resultado._ValorQuadra.Should().Be(valorEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(valorEsperadoQuina);
            _resultado._ValorSena.Should().Be(valorEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_SharePremium_SenaAwarded_ShouldBeOk()
        {

            var valorEsperadoSena = 100;
            var valorEsperadoQuina = 0;
            var valorEsperadoQuadra = 0;

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;

            _resultado.DividirPremios(0, 0, 1);

            _resultado._ValorQuadra.Should().Be(valorEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(valorEsperadoQuina);
            _resultado._ValorSena.Should().Be(valorEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_SharePremium_QuinaAwarded_ShouldBeOk()
        {

            var valorEsperadoSena = 0;
            var valorEsperadoQuina = 25;
            var valorEsperadoQuadra = 0;

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;

            _resultado.DividirPremios(0, 0.25, 0);

            _resultado._ValorQuadra.Should().Be(valorEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(valorEsperadoQuina);
            _resultado._ValorSena.Should().Be(valorEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_SharePremium_SenaAndQuadraAwarded_ShouldBeOk()
        {

            var valorEsperadoSena = 90;
            var valorEsperadoQuina = 0;
            var valorEsperadoQuadra = 10;

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;

            _resultado.DividirPremios(0.1, 0, 0.9);

            _resultado._ValorQuadra.Should().Be(valorEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(valorEsperadoQuina);
            _resultado._ValorSena.Should().Be(valorEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_SharePremium_QuinaAndQuadraAwarded_ShouldBeOk()
        {

            var valorEsperadoSena = 0;
            var valorEsperadoQuina = 20;
            var valorEsperadoQuadra = 10;

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;

            _resultado.DividirPremios(0.1, 0.2, 0);

            _resultado._ValorQuadra.Should().Be(valorEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(valorEsperadoQuina);
            _resultado._ValorSena.Should().Be(valorEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_RewardQuadra_AllAwarded_ShouldBeOk()
        {
            var premioEsperadoSena = 70;
            var premioEsperadoQuina = 20;
            var premioEsperadoQuadra = 10;

            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SENA);
            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUADRA);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUINA);

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;
            _resultado.GanhadoresQuadra = 1;
            _resultado.GanhadoresQuina = 1;
            _resultado.GanhadoresSena = 1;

            _resultado.PremiarQuadra();

            _resultado._ValorQuadra.Should().Be(premioEsperadoQuadra);
            _resultado._ValorQuina.Should().Be(premioEsperadoQuina);
            _resultado._ValorSena.Should().Be(premioEsperadoSena);
        }

        [Test]
        public void Resultado_TestDomain_RewardQuadra_QuadraAndSenaAwarded_ShouldBeOk()
        {
            var premioEsperadoSena = 90;
            var premioEsperadoQuina = 0;
            var premioEsperadoQuadra = 10;

            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUADRA);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SENA);

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;
            _resultado.GanhadoresQuadra = 1;
            _resultado.GanhadoresQuina = 0;
            _resultado.GanhadoresSena = 1;

            _resultado.PremiarQuadra();

            _resultado._Ganhadores[0]._ValorPremio.Should().Be(premioEsperadoSena);
            _resultado._Ganhadores[1]._ValorPremio.Should().Be(premioEsperadoQuina);
            _resultado._Ganhadores[2]._ValorPremio.Should().Be(premioEsperadoQuadra);
        }

        [Test]
        public void Resultado_TestDomain_RewardQuadra_JustSenaAwarded_ShouldBeOk()
        {
            var premioEsperadoSena = 100;
            var premioEsperadoQuina = 0;
            var premioEsperadoQuadra = 0;

            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SENA);

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;
            _resultado.GanhadoresQuadra = 0;
            _resultado.GanhadoresQuina = 0;
            _resultado.GanhadoresSena = 1;

            _resultado.PremiarQuadra();

            _resultado._Ganhadores[0]._ValorPremio.Should().Be(premioEsperadoSena);
            _resultado._Ganhadores[1]._ValorPremio.Should().Be(premioEsperadoQuina);
            _resultado._Ganhadores[2]._ValorPremio.Should().Be(premioEsperadoQuadra);
        }

        [Test]
        public void Resultado_TestDomain_NoWinners_ShouldBeOk()
        {
            var premioEsperadoSena = 0;
            var premioEsperadoQuina = 0;
            var premioEsperadoQuadra = 0;

            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;
            _resultado.GanhadoresQuadra = 0;
            _resultado.GanhadoresQuina = 0;
            _resultado.GanhadoresSena = 0;

            _resultado.PremiarQuadra();

            _resultado._Ganhadores[0]._ValorPremio.Should().Be(premioEsperadoSena);
            _resultado._Ganhadores[1]._ValorPremio.Should().Be(premioEsperadoQuina);
            _resultado._Ganhadores[2]._ValorPremio.Should().Be(premioEsperadoQuadra);
        }

        [Test]
        public void Resultado_TestDomain_RewardQuadra_QuinaAndSenaAwarded_ShouldBeOk()
        {
            var premioEsperadoSena = 75;
            var premioEsperadoQuina = 25;
            var premioEsperadoQuadra = 0;

            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SEMPREMIACAO);
            ganhadorQuina.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUINA);
            ganhadorSena.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.SENA);

            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);
            _resultado._Concurso._Apostas = listAposta;
            _resultado._ValorTotal = 100;
            _resultado.GanhadoresQuadra = 0;
            _resultado.GanhadoresQuina = 1;
            _resultado.GanhadoresSena = 1;

            _resultado.PremiarQuadra();

            _resultado._Ganhadores[0]._ValorPremio.Should().Be(premioEsperadoSena);
            _resultado._Ganhadores[1]._ValorPremio.Should().Be(premioEsperadoQuina);
            _resultado._Ganhadores[2]._ValorPremio.Should().Be(premioEsperadoQuadra);
        }

        [Test]
        public void Resultado_TestDomain_VerifyListBets_ShouldBeOk()
        {
            var tipoEsperado = Ganhador.TipoPremio.SENA;
            _resultado = ObjectMother.GetResultadoOk(_concurso.Object, listGanhadores);

            ganhadorQuadra.Setup(m => m._TipoPremio).Returns(Ganhador.TipoPremio.QUADRA);

            _resultado._Concurso._Apostas = listAposta;
            _resultado._Resultado = listDezenas;

            _resultado.VerificarListAposta();

            _resultado._Ganhadores.Last()._TipoPremio.Should().Be(tipoEsperado);

        }

        [Test]
        public void Resultado_TestDomain_VerifyListBets_ShouldBeFail()
        {
            _resultado._Concurso = null;

            Action comparation = () => _resultado.Validate();

            comparation.Should().Throw<ResultadoConcursoNullException>();
        }


    }
}
