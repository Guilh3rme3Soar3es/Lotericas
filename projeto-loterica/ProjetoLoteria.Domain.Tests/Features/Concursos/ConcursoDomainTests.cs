using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoteria.Domain.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoDomainTests
    {
        Concurso concurso;
        List<Aposta> ListApostas;

        Mock<Aposta> FakeAposta1;
        Mock<Aposta> FakeAposta2;

        [SetUp]
        public void Initialize()
        {
            FakeAposta1 = new Mock<Aposta>();
            FakeAposta2 = new Mock<Aposta>();

            ListApostas = new List<Aposta>()
            {
                FakeAposta1.Object,
                FakeAposta2.Object
            };
            concurso = ObjectMother.GetConcurso(ListApostas);
        }

        [Test]
        public void Concurso_TestDomain_ShouldBeOk()
        {
            Action comparation = () => concurso.Validate();

            comparation.Should().NotThrow();
        }

        [Test]
        public void Concurso_TestDomain_ConcursoInvalidNumber_ShouldBeFail()
        {
            concurso._Numero = 0;

            Action comparation = () => concurso.Validate();

            comparation.Should().Throw<ConcursoInvalidNumberException>();

        }
        

    }
}
