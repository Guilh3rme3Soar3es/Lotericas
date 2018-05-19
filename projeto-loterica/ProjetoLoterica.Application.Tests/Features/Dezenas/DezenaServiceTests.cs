using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoteria.Application.Features.Dezenas;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Exceptions;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Dezenas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Application.Tests.Features.Dezenas
{
    [TestFixture]
    public class DezenaServiceTests
    {
        private Mock<IDezenaRepository> _mockRepository;

        private DezenaService _service;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IDezenaRepository>();
            _service = new DezenaService(_mockRepository.Object);
        }

        [Test]
        public void Dezena_ServiceTests_AddDozen_ShouldBeOk()
        {
            Dezena dezenaToSave = ObjectMother.GetDezenas();

            _mockRepository.Setup(dr => dr.Save(dezenaToSave)).Returns(dezenaToSave);

            Action comparation = () => _service.Add(dezenaToSave);

            comparation.Should().NotThrow();
            _mockRepository.Verify(dr => dr.Save(dezenaToSave));
        }

        [Test]
        public void Dezena_ServiceTests_AddDozen_InvalidDozen_ShouldBeFail()
        {
            Dezena dezenaToSave = ObjectMother.GetDezenas();
            dezenaToSave._Dezena = 0;

            _mockRepository.Setup(dr => dr.Save(dezenaToSave)).Returns(dezenaToSave);

            Action comparation = () => _service.Add(dezenaToSave);

            comparation.Should().Throw<DezenaInvalidValueException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Dezena_ServiceTests_UpdateDozen_ShouldBeOk()
        {
            Dezena dezenaToUpdate = ObjectMother.GetDezenas();
            dezenaToUpdate.id = 1;

            _mockRepository.Setup(dr => dr.Update(dezenaToUpdate)).Returns(dezenaToUpdate);

            Action comparation = () => _service.Update(dezenaToUpdate);

            comparation.Should().NotThrow();
            _mockRepository.Verify(dr => dr.Update(dezenaToUpdate));
        }

        [Test]
        public void Dezena_ServiceTests_UpdateDozen_InvalidId_ShouldBeFail()
        {
            Dezena dezenaToUpdate = ObjectMother.GetDezenas();
            dezenaToUpdate.id = -1;

            _mockRepository.Setup(dr => dr.Update(dezenaToUpdate)).Returns(dezenaToUpdate);

            Action comparation = () => _service.Update(dezenaToUpdate);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Dezena_ServiceTests_UpdateDozen_InvalidDozen_ShouldBeFail()
        {
            Dezena dezenaToUpdate = ObjectMother.GetDezenas();
            dezenaToUpdate.id = 1;
            dezenaToUpdate._Dezena = 0;
            _mockRepository.Setup(dr => dr.Update(dezenaToUpdate)).Returns(dezenaToUpdate);

            Action comparation = () => _service.Update(dezenaToUpdate);

            comparation.Should().Throw<DezenaInvalidValueException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Dezena_ServiceTests_GetDozen_ShouldBeOk()
        {
            Dezena dezenaToFind = ObjectMother.GetDezenas();
            dezenaToFind.id = 1;
            _mockRepository.Setup(dr => dr.Get(dezenaToFind.id)).Returns(dezenaToFind);

            Action comparation = () => _service.Get(dezenaToFind.id);

            comparation.Should().NotThrow();
            _mockRepository.Verify(dr => dr.Get(dezenaToFind.id));
        }

        [Test]
        public void Dezena_ServiceTests_GetDozen_InvalidId_ShouldBeFail()
        {
            Dezena dezenaToFind = ObjectMother.GetDezenas();
            dezenaToFind.id = -1;
            _mockRepository.Setup(dr => dr.Get(dezenaToFind.id)).Returns(dezenaToFind);

            Action comparation = () => _service.Get(dezenaToFind.id);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Dezena_ServiceTests_GetDozen_ShouldBeNull()
        {
            Dezena dezenaToFind = ObjectMother.GetDezenas();
            dezenaToFind.id = 1;
            _mockRepository.Setup(dr => dr.Get(dezenaToFind.id));

            Dezena dezenaFinded = _service.Get(dezenaToFind.id);

            dezenaFinded.Should().BeNull();
            _mockRepository.Verify(dr => dr.Get(dezenaToFind.id));
        }

        [Test]
        public void Dezena_ServiceTests_GetAll_ShouldBeOk()
        {
            Dezena dezenaToFind = ObjectMother.GetDezenas();
            dezenaToFind.id = 1;

            _mockRepository.Setup(dr => dr.GetAll()).Returns(new List<Dezena> { dezenaToFind });

            var listDezenas = _service.GetAll();

            listDezenas.Count().Should().BeGreaterThan(0);
            _mockRepository.Verify(dr => dr.GetAll());
        }

        [Test]
        public void Dezena_ServiceTest_GetAll_ShouldBeNull()
        {
            Dezena dezenaToFind = ObjectMother.GetDezenas();
            dezenaToFind.id = 1;

            _mockRepository.Setup(dr => dr.GetAll());

            var listDezenas = _service.GetAll();

            listDezenas.Should().BeNull();
            _mockRepository.Verify(dr => dr.GetAll());
        }

        [Test]
        public void Dezena_ServiceTest_Delete_ShouldBeOk()
        {
            Dezena dezenaToDelete = ObjectMother.GetDezenas();
            dezenaToDelete.id = 1;

            _mockRepository.Setup(dr => dr.Delete(dezenaToDelete));

            _service.Delete(dezenaToDelete);

            _mockRepository.Verify(dr => dr.Delete(dezenaToDelete));
        }

        [Test]
        public void Dezena_ServiceTest_Delete_InvalidId_ShouldBeFail()
        {
            Dezena dezenaToDelete = ObjectMother.GetDezenas();
            dezenaToDelete.id = -1;

            _mockRepository.Setup(dr => dr.Delete(dezenaToDelete));

            Action comparation = () => _service.Delete(dezenaToDelete);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
