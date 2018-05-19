using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoteria.Application.Features.Apostas;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Exceptions;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Boloes;
using ProjetoLoterica.Domain.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Application.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaServiceTests
    {
        private Concurso _concurso;
        private Bolao _bolao;
        
        private Mock<IApostaRepository> _mockRepository;

        private ApostaService _service;

        [SetUp]
        public void Initialize()
        {
            _concurso = ObjectMother.GetConcurso();
            _bolao = new Bolao();
            _mockRepository = new Mock<IApostaRepository>();

            _service = new ApostaService(_mockRepository.Object);

        }

        [Test]
        public void Aposta_ServiceTest_AddBet_ShouldBeOk()
        {
            Aposta apostaToSave = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToSave._Dezenas = ObjectMother.GetListDezenas(apostaToSave);
            _mockRepository.Setup(ar => ar.Save(apostaToSave)).Returns(apostaToSave);

            Action comparation = () => _service.Add(apostaToSave);

            comparation.Should().NotThrow();
            _mockRepository.Verify(ar => ar.Save(apostaToSave));
        }

        [Test]
        public void Aposta_ServiceTest_AddBet_ShouldBeFail()
        {
            Aposta apostaToSave = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToSave._Concurso = null;
            apostaToSave._Dezenas = ObjectMother.GetListDezenas(apostaToSave);
            _mockRepository.Setup(ar => ar.Save(apostaToSave)).Returns(apostaToSave);

            Action comparation = () => _service.Add(apostaToSave);

            comparation.Should().Throw<ApostaInvalidContestException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Aposta_ServiceTest_UpdateBet_ShouldBeOk()
        {
            Aposta apostaToUpdate = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToUpdate._Dezenas = ObjectMother.GetListDezenas(apostaToUpdate);
            apostaToUpdate.id = 1;
            _mockRepository.Setup(ar => ar.Update(apostaToUpdate)).Returns(apostaToUpdate);

            Action comparation = () => _service.Update(apostaToUpdate);

            comparation.Should().NotThrow();
            _mockRepository.Verify(ar => ar.Update(apostaToUpdate));
        }

        [Test]
        public void Aposta_ServiceTest_UpdateBet_InvalidId_ShouldBeFail()
        {
            Aposta apostaToUpdate = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToUpdate._Dezenas = ObjectMother.GetListDezenas(apostaToUpdate);
            apostaToUpdate.id = -1;
            _mockRepository.Setup(ar => ar.Update(apostaToUpdate)).Returns(apostaToUpdate);

            Action comparation = () => _service.Update(apostaToUpdate);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Aposta_ServiceTest_UpdateBet_InvalidBet_ShouldBeFail()
        {
            Aposta apostaToUpdate = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToUpdate._Dezenas = ObjectMother.GetListDezenas(apostaToUpdate);
            apostaToUpdate.id = 1;
            apostaToUpdate._Concurso = null;
            _mockRepository.Setup(ar => ar.Update(apostaToUpdate)).Returns(apostaToUpdate);

            Action comparation = () => _service.Update(apostaToUpdate);

            comparation.Should().Throw<ApostaInvalidContestException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Aposta_ServiceTest_GetBet_ShouldBeOk()
        {
            Aposta apostaToFind = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToFind._Dezenas = ObjectMother.GetListDezenas(apostaToFind);
            apostaToFind.id = 1;
            _mockRepository.Setup(ar => ar.Get(apostaToFind.id)).Returns(apostaToFind);

            Action comparation = () => _service.Get(apostaToFind.id);

            comparation.Should().NotThrow();
            _mockRepository.Verify(ar => ar.Get(apostaToFind.id));
        }

        [Test]
        public void Aposta_ServiceTest_GetBet_InvalidId_ShouldBeFail()
        {
            Aposta apostaToFind = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToFind._Dezenas = ObjectMother.GetListDezenas(apostaToFind);
            apostaToFind.id = -1;
            _mockRepository.Setup(ar => ar.Get(apostaToFind.id)).Returns(apostaToFind);

            Action comparation = () => _service.Get(apostaToFind.id);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Aposta_ServiceTest_GetBet_ShouldBeNull()
        {
            Aposta apostaToFind = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToFind._Dezenas = ObjectMother.GetListDezenas(apostaToFind);
            apostaToFind.id = 1;
            _mockRepository.Setup(ar => ar.Get(apostaToFind.id));

            Aposta apostaFinded  = _service.Get(apostaToFind.id);

            apostaFinded.Should().BeNull();
            _mockRepository.Verify(ar => ar.Get(apostaToFind.id));
        }

        [Test]
        public void Aposta_ServiceTest_GetAll_ShouldBeOk()
        {
            Aposta apostaToFind = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToFind._Dezenas = ObjectMother.GetListDezenas(apostaToFind);
            apostaToFind.id = 1;

            _mockRepository.Setup(ar => ar.GetAll()).Returns(new List<Aposta> { apostaToFind });

            var listApostas = _service.GetAll();

            listApostas.Count().Should().BeGreaterThan(0);
            _mockRepository.Verify(ar => ar.GetAll());
        }

        [Test]
        public void Aposta_ServiceTest_GetAll_ShouldBeNull()
        {
            _mockRepository.Setup(ar => ar.GetAll());

            var listApostas = _service.GetAll();

            listApostas.Should().BeNull();
            _mockRepository.Verify(ar => ar.GetAll());
        }

        [Test]
        public void Aposta_ServiceTest_DeleteBet_ShouldBeOk()
        {
            Aposta apostaToDelete = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToDelete._Dezenas = ObjectMother.GetListDezenas(apostaToDelete);
            apostaToDelete.id = 1;
            _mockRepository.Setup(pr => pr.Delete(apostaToDelete));

            _service.Delete(apostaToDelete);

            _mockRepository.Verify(br => br.Delete(apostaToDelete));
        }

        [Test]
        public void Aposta_ServiceTest_DeleteBet_InvalidId_ShouldBeFail()
        {
            Aposta apostaToDelete = ObjectMother.GetAposta(_bolao, _concurso);
            apostaToDelete._Dezenas = ObjectMother.GetListDezenas(apostaToDelete);
            apostaToDelete.id = -1;
            _mockRepository.Setup(pr => pr.Delete(apostaToDelete));

            Action comparation = () =>_service.Delete(apostaToDelete);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
