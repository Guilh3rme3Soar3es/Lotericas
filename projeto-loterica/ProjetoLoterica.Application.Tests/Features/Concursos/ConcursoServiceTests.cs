using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoteria.Application.Features.Concursos;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Exceptions;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Application.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoServiceTests
    {
        private Mock<IConcursoRepository> _mockRepository;
        private ConcursoService _service;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IConcursoRepository>();
            _service = new ConcursoService(_mockRepository.Object);
        }

        [Test]
        public void Contest_ServiceTest_AddContest_ShouldBeOK()
        {
            Concurso concursoToSave = ObjectMother.GetConcurso();
            _mockRepository.Setup(cr => cr.Save(concursoToSave)).Returns(concursoToSave);

            Action comparation = () => _service.Add(concursoToSave);

            comparation.Should().NotThrow();
            _mockRepository.Verify(cr => cr.Save(concursoToSave));
        }

        [Test]
        public void Contest_ServiceTest_AddContest_InvalidContest_ShouldBeFail()
        {
            Concurso concursoToSave = ObjectMother.GetConcurso();
            concursoToSave._Numero = 0;
            _mockRepository.Setup(cr => cr.Save(concursoToSave)).Returns(concursoToSave);

            Action comparation = () => _service.Add(concursoToSave);

            comparation.Should().Throw<ConcursoInvalidNumberException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_ServiceTest_UpdateContest_ShouldBeOK()
        {
            Concurso concursoToUpdate = ObjectMother.GetConcurso();
            concursoToUpdate.id = 1;
            _mockRepository.Setup(cr => cr.Update(concursoToUpdate)).Returns(concursoToUpdate);

            Action comparation = () => _service.Update(concursoToUpdate);

            comparation.Should().NotThrow();
            _mockRepository.Verify(cr => cr.Update(concursoToUpdate));
        }

        [Test]
        public void Contest_ServiceTest_UpdateContest_InvalidId_ShouldBeFail()
        {
            Concurso concursoToUpdate = ObjectMother.GetConcurso();
            concursoToUpdate.id = -1;
            _mockRepository.Setup(cr => cr.Update(concursoToUpdate)).Returns(concursoToUpdate);

            Action comparation = () => _service.Update(concursoToUpdate);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_ServiceTest_UpdateContest_InalidContest_ShouldBeFail()
        {
            Concurso concursoToUpdate = ObjectMother.GetConcurso();
            concursoToUpdate.id = 1;
            concursoToUpdate._Numero = 0;
            _mockRepository.Setup(cr => cr.Update(concursoToUpdate)).Returns(concursoToUpdate);

            Action comparation = () => _service.Update(concursoToUpdate);

            comparation.Should().Throw<ConcursoInvalidNumberException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_ServiceTest_GetContest_ShouldBeOk()
        {
            Concurso concursoToFind = ObjectMother.GetConcurso();
            concursoToFind.id = 1;

            _mockRepository.Setup(cr => cr.Get(concursoToFind.id)).Returns(concursoToFind);

            Action comparation = () => _service.Get(concursoToFind.id);

            comparation.Should().NotThrow();
            _mockRepository.Verify(cr => cr.Get(concursoToFind.id));
        }

        [Test]
        public void Contest_ServiceTest_GetContest_InvalidId_ShouldBeFail()
        {
            Concurso concursoToFind = ObjectMother.GetConcurso();
            concursoToFind.id = -1;

            _mockRepository.Setup(cr => cr.Get(concursoToFind.id)).Returns(concursoToFind);

            Action comparation = () => _service.Get(concursoToFind.id);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Contest_ServiceTest_GetContest_ShouldBeNull()
        {
            Concurso concursoToFind = ObjectMother.GetConcurso();
            concursoToFind.id = 1;

            _mockRepository.Setup(cr => cr.Get(concursoToFind.id));

            Concurso concursoFinded = _service.Get(concursoToFind.id);

            concursoFinded.Should().BeNull();
            _mockRepository.Verify(cr => cr.Get(concursoToFind.id));
        }

        [Test]
        public void Contest_ServiceTest_GetAll_ShouldBeOk()
        {
            Concurso concursoToFind = ObjectMother.GetConcurso();
            concursoToFind.id = 1;

            _mockRepository.Setup(cr => cr.GetAll()).Returns(new List<Concurso> { concursoToFind });

            var listConcursos = _service.GetAll();

            listConcursos.Count().Should().BeGreaterThan(0);
            _mockRepository.Verify(cr => cr.GetAll());
        }

        [Test]
        public void Contest_ServiceTest_GetAll_ShouldBeNull()
        {
            Concurso concursoToFind = ObjectMother.GetConcurso();
            concursoToFind.id = 1;

            _mockRepository.Setup(cr => cr.GetAll());

            var listConcursos = _service.GetAll();

            listConcursos.Should().BeNull();
            _mockRepository.Verify(cr => cr.GetAll());
        }

        [Test]
        public void Contest_ServiceTest_Delete_ShouldBeOk()
        {
            Concurso concursoToDelete = ObjectMother.GetConcurso();
            concursoToDelete.id = 1;

            _mockRepository.Setup(cr => cr.Delete(concursoToDelete));

            _service.Delete(concursoToDelete);

            _mockRepository.Verify(cr => cr.Delete(concursoToDelete));
        }

        [Test]
        public void Contest_ServiceTest_Delete_InvalidId_ShouldBeFail()
        {
            Concurso concursoToDelete = ObjectMother.GetConcurso();
            concursoToDelete.id = -1;

            _mockRepository.Setup(cr => cr.Delete(concursoToDelete));

            Action comparation = () => _service.Delete(concursoToDelete);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
