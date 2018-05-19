using Moq;
using NUnit.Framework;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ProjetoLoterica.Domain.Features.Apostas;

namespace ProjetoLoteria.Domain.Tests.Features.Dezenas
{
    [TestFixture]
    public class DezenaDomainTests
    {
        Mock<Aposta> _FakeAposta;
        Dezena _dezena = new Dezena();

        [SetUp]
        public void initialize()
        {
            _FakeAposta = new Mock<Aposta>();

            _dezena = ObjectMother.GetDezenas(_FakeAposta.Object);
        }


        [Test]
        public void Dezena_TestDomain_ShouldBeOk()
        {
            Action comparation = () => { _dezena.Validate(); };

            comparation.Should().NotThrow();
        }


        [Test]
        public void Dezena_TestDomain_InvalidDozens_ShouldBeFail()
        {
            _dezena._Dezena = -1;

            Action comparation = () => { _dezena.Validate(); };

            comparation.Should().Throw<DezenaInvalidValueException>();
        }

        //Verificar...
        //[Test]
        //public void Dezena_TestDomain_InvalidAposta_ShouldBeFail()
        //{
        //    _dezena._Aposta = null;

        //    Action comparation = () => { _dezena.Validate(); };

        //    comparation.Should().Throw<DezenaInvalidApostaException>();
        //}

    }
}
