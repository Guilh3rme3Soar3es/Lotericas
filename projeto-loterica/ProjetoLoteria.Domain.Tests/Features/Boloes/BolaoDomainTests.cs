using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Boloes;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Domain.Tests.Features.Boloes
{
    [TestFixture]
    public class BolaoDomainTests
    {
        private List<Aposta> _listApostas;
        private Mock<Aposta> _fakeAposta;
        private Mock<Aposta> _fakeAposta2;
        private Mock<Concurso> _concurso;

        [SetUp]
        public void Initialize()
        {
            _listApostas = new List<Aposta>();
            _fakeAposta = new Mock<Aposta>();
            _fakeAposta2 = new Mock<Aposta>();

            _concurso = new Mock<Concurso>();

            _fakeAposta2.Setup(m => m.Valor).Returns(9);
            _fakeAposta.Setup(m => m.Valor).Returns(3);

            _listApostas.Add(_fakeAposta.Object);
            _listApostas.Add(_fakeAposta2.Object);
        }

        [Test]
        public void Bolao_TestDomain_ShouldBeOk()
        {
            Bolao bolao = ObjectMother.GetBolao(_listApostas);
            bolao.QtdApostas = 2;
            bolao.GetValorTotal();

            Action comparation = () => bolao.Validate();

            comparation.Should().NotThrow();
        }

        [Test]
        public void Bolao_TestDomain_NullList_ShouldBeFail()
        {
            Bolao bolao = ObjectMother.GetBolao(_listApostas);
            bolao._Aposta = null;

            Action comparation = () => bolao.Validate();

            comparation.Should().Throw<BolaoListNullException>();
        }

        [Test]
        public void Bolao_TestDomain_EmptyList_ShouldBeFail()
        {
            Bolao bolao = ObjectMother.GetBolao(_listApostas);
            bolao._Aposta = new List<Aposta>();

            Action comparation = () => bolao.Validate();

            comparation.Should().Throw<BolaoListApostasEmptyException>();
        }

        [Test]
        public void Bolao_TestDomain_GetValorTotal_ShouldBeOk()
        {
            // Cenário
            double valorTotal = 12;
            Bolao bolao = ObjectMother.GetBolao(_listApostas);

            // Ação
            bolao.GetValorTotal();

            // Verificação
            bolao._ValorTotal.Should().Be(valorTotal);
        }

        [Test]
        public void Bolao_TestDomain_GetValorTotal_ShouldBeFail()
        {
            // Cenário
            double valorTotal = 10;
            Bolao bolao = ObjectMother.GetBolao(_listApostas);

            // Ação
            bolao.GetValorTotal();

            // Verificação
            bolao._ValorTotal.Should().NotBe(valorTotal);
        }
        
        [Test]
        public void Bolao_TestDomain_GerarBolao_ShouldBeOk()
        {
            int quantidadeApostas = 5;
            Bolao bolao = new Bolao();

            Bolao resultadoEncontrado = bolao.GerarBolao(quantidadeApostas);

            resultadoEncontrado.QtdApostas.Should().Be(quantidadeApostas); 
        }

        [Test]
        public void Bolao_TestDomain_GerarApostas_ShouldBeOk()
        {
            _concurso = new Mock<Concurso>();            
            int quantidadeApostas = 5;
            Bolao bolao = new Bolao();
            Bolao bolaoGerado = bolao.GerarBolao(quantidadeApostas);

            bolaoGerado.GerarApostas(quantidadeApostas, _concurso.Object);

            bolaoGerado._Aposta.Count.Should().Be(quantidadeApostas);
        }
    }
}
