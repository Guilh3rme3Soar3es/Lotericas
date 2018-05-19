using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoteria.Application.Features.Ganhadores;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Exceptions;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Apostas.Ganhadores;
using ProjetoLoterica.Domain.Features.Boloes;
using ProjetoLoterica.Domain.Features.Concursos;
using ProjetoLoterica.Domain.Features.Ganhadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Application.Tests.Features.Ganhadores
{
    [TestFixture]
    public class GanhadorServiceTests
    {
        private Mock<IGanhadorRepository> _mockRepository;

        private GanhadorService _service;

        private Bolao _bolao;
        private Concurso _concurso;
        private List<Dezena> _listDezenas;
        private Aposta _aposta;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IGanhadorRepository>();
            _service = new GanhadorService(_mockRepository.Object);

            _bolao = new Bolao();
            _concurso = ObjectMother.GetConcurso();
            _aposta = ObjectMother.GetAposta(_bolao, _concurso);
            _listDezenas = ObjectMother.GetListDezenas(_aposta);
            _aposta._Dezenas = _listDezenas;
        }

        [Test]
        public void Ganhador_ServiceTests_AddWinner_ShouldBeOk()
        {
            Ganhador ganhadorToSave = ObjectMother.GetGanhador(_aposta, _concurso);

            _mockRepository.Setup(gr => gr.Save(ganhadorToSave)).Returns(ganhadorToSave);

            Action comparation = () => _service.Add(ganhadorToSave);

            comparation.Should().NotThrow();
            _mockRepository.Verify(gr => gr.Save(ganhadorToSave));
        }

        [Test]
        public void Ganhador_ServiceTests_AddWinner_InvalidWinner_ShouldBeFail()
        {
            Ganhador ganhadorToSave = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToSave.Concurso = null;
            _mockRepository.Setup(gr => gr.Save(ganhadorToSave)).Returns(ganhadorToSave);

            Action comparation = () => _service.Add(ganhadorToSave);

            comparation.Should().Throw<GanhadorNullContestException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Ganhador_ServiceTests_UpdateWinner_ShouldBeOk()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = 1;

            _mockRepository.Setup(gr => gr.Update(ganhadorToUpdate)).Returns(ganhadorToUpdate);

            Action comparation = () => _service.Update(ganhadorToUpdate);

            comparation.Should().NotThrow();
            _mockRepository.Verify(gr => gr.Update(ganhadorToUpdate));
        }

        [Test]
        public void Ganhador_ServiceTests_UpdateWinner_InvalidId_ShouldBeFail()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = -1;

            _mockRepository.Setup(gr => gr.Update(ganhadorToUpdate)).Returns(ganhadorToUpdate);

            Action comparation = () => _service.Update(ganhadorToUpdate);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Ganhador_ServiceTests_UpdateWinner_InvalidWinner_ShouldBeFail()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = 1;
            ganhadorToUpdate.Concurso = null;

            _mockRepository.Setup(gr => gr.Update(ganhadorToUpdate)).Returns(ganhadorToUpdate);

            Action comparation = () => _service.Update(ganhadorToUpdate);

            comparation.Should().Throw<GanhadorNullContestException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Ganhador_ServiceTests_GetWinner__ShouldBeOk()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = 1;

            _mockRepository.Setup(gr => gr.Get(ganhadorToUpdate.id)).Returns(ganhadorToUpdate);

            Action comparation = () => _service.Get(ganhadorToUpdate.id);

            comparation.Should().NotThrow();
            _mockRepository.Verify(gr => gr.Get(ganhadorToUpdate.id));
        }

        [Test]
        public void Ganhador_ServiceTests_GetWinner_InvalidId_ShouldBeFail()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = -1;

            _mockRepository.Setup(gr => gr.Get(ganhadorToUpdate.id)).Returns(ganhadorToUpdate);

            Action comparation = () => _service.Get(ganhadorToUpdate.id);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Ganhador_ServiceTests_GetWinner_ShouldBeNull()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = 1;

            _mockRepository.Setup(gr => gr.Get(ganhadorToUpdate.id));

            Ganhador ganhadorFinded = _service.Get(ganhadorToUpdate.id);

            ganhadorFinded.Should().BeNull();
            _mockRepository.Verify(gr => gr.Get(ganhadorToUpdate.id));
        }

        [Test]
        public void Ganhador_ServiceTests_GetAll__ShouldBeOk()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = 1;

            _mockRepository.Setup(gr => gr.GetAll()).Returns(new List<Ganhador> { ganhadorToUpdate });

            Action comparation = () => _service.GetAll();

            comparation.Should().NotThrow();
            _mockRepository.Verify(gr => gr.GetAll());
        }

        [Test]
        public void Ganhador_ServiceTests_GetAll__ShouldBeNull()
        {
            Ganhador ganhadorToUpdate = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToUpdate.id = 1;

            _mockRepository.Setup(gr => gr.GetAll());

            var listGanhadores = _service.GetAll();

            listGanhadores.Should().BeNull();
            _mockRepository.Verify(gr => gr.GetAll());
        }

        [Test]
        public void Ganhador_ServiceTest_Delete_ShouldBeOk()
        {
            Ganhador ganhadorToDelete = ObjectMother.GetGanhador(_aposta,_concurso);
            ganhadorToDelete.id = 1;

            _mockRepository.Setup(gr => gr.Delete(ganhadorToDelete));

            _service.Delete(ganhadorToDelete);

            _mockRepository.Verify(gr => gr.Delete(ganhadorToDelete));
        }

        [Test]
        public void Ganhador_ServiceTest_Delete_InvalidId_ShouldBeFail()
        {
            Ganhador ganhadorToDelete = ObjectMother.GetGanhador(_aposta, _concurso);
            ganhadorToDelete.id = -1;

            _mockRepository.Setup(gr => gr.Delete(ganhadorToDelete));

            Action comparation = () => _service.Delete(ganhadorToDelete);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
