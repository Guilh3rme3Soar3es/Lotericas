using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Boloes;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Domain.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaDomainTests
    {
        private Aposta _aposta;

        List<Dezena> listDezenas;
        List<Aposta> listApostas;

        private Mock<Dezena> _fakePrimeiraDezena;
        private Mock<Dezena> _fakeSegundaDezena;
        private Mock<Dezena> _fakeTerceiraDezena;
        private Mock<Dezena> _fakeQuartaDezena;
        private Mock<Dezena> _fakeQuintaDezena;
        private Mock<Dezena> _fakeSextaDezena;

        private Mock<Bolao> _fakeBolao;
        private Mock<Concurso> _fakeConcurso;
        [SetUp]
        public void Initialize()
        {
            _fakeBolao = new Mock<Bolao>();
            _fakeConcurso = new Mock<Concurso>();

            _aposta = ObjectMother.GetAposta(_fakeBolao.Object, _fakeConcurso.Object);

            listApostas = new List<Aposta>();
            listApostas.Add(_aposta);

            _fakePrimeiraDezena = new Mock<Dezena>();
            _fakeSegundaDezena = new Mock<Dezena>();
            _fakeTerceiraDezena = new Mock<Dezena>();
            _fakeQuartaDezena = new Mock<Dezena>();
            _fakeQuintaDezena = new Mock<Dezena>();
            _fakeSextaDezena = new Mock<Dezena>();

            listDezenas = new List<Dezena>() {
                _fakePrimeiraDezena.Object,
                _fakeSegundaDezena.Object,
                _fakeTerceiraDezena.Object,
                _fakeQuartaDezena.Object,
                 _fakeQuintaDezena.Object,
                 _fakeSextaDezena.Object
             };

            _aposta._Dezenas = listDezenas;
        }

        [Test]
        public void Aposta_TestDomain_ShouldBeOk()
        {
            _aposta._Dezenas = listDezenas;

            Action comparation = () => _aposta.Validate();

            comparation.Should().NotThrow();
        }

        [Test]
        public void Aposta_TestDomain_ApostaInvalidValue_ShouldBeFail()
        {
            _aposta.Valor = 0;

            Action comparation = () => _aposta.Validate();

            comparation.Should().Throw<ApostaInvalidValueException>();
        }

        [Test]
        public void Aposta_TestDomain_ApostaInvalidDozens_ShouldBeFail()
        {
            listDezenas.RemoveRange(1, 1);
            _aposta._Dezenas = listDezenas;

            Action comparation = () => _aposta.Validate();

            comparation.Should().Throw<ApostaInvalidDozensException>();
        }

        [Test]
        public void Aposta_TestDomain_ApostaCalcTotalValue_ShouldBeOk()
        {
            _aposta.Valor = 100;

            _aposta.EstaNoBolao();

            _aposta.ValorTotal.Should().Be(105);
        }

        [Test]
        public void Aposta_TestDomain_ApostaCalcTotalValue_ShouldBeFail()
        {
            _aposta.Valor = 110;

            _aposta.EstaNoBolao();

            _aposta.ValorTotal.Should().NotBe(105);
        }

        [Test]
        public void Aposta_TestDomain_ApostaTotalValueSmallerValor_ShouldBeFail()
        {
            _aposta.Valor = 11;
            _aposta.ValorTotal = 10;
            Action comparation = () => _aposta.Validate();

            comparation.Should().Throw<ApostaInvalidTotalValueException>();
        }

        [Test]
        public void Aposta_TestDomain_ApostaInvalidContest_ShouldBeFail()
        {
            _aposta._Concurso = null;

            Action comparation = () => _aposta.Validate();

            comparation.Should().Throw<ApostaInvalidContestException>();

        }

        [Test]
        public void Aposta_TestDomain_GetValor_ShouldBeOk()
        {
            _aposta.GerarValor();

            _aposta.Valor.Should().Be(3);
        }

        [Test]
        public void Aposta_TestDomain_GetValor_ShouldBeFail()
        {
            _aposta._Dezenas.Remove(_fakePrimeiraDezena.Object);
            _aposta.GerarValor();

            _aposta.Valor.Should().NotBe(3);

        }

    }
}
