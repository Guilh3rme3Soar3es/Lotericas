using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoLoteria.Application.Features.Boloes;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Exceptions;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Application.Tests.Features.Boloes
{
    [TestFixture]
    public class BolaoServiceTests
    {
        private Mock<IBolaoRepository> _mockRepository;
        private Mock<Aposta> _aposta;

        private List<Aposta> _listApostas;
        private BolaoService _service;

        [SetUp]
        public void Initialize()
        {
            _aposta = new Mock<Aposta>();

            _listApostas = new List<Aposta>()
            {
                _aposta.Object
            };

            _mockRepository = new Mock<IBolaoRepository>();
            _service = new BolaoService(_mockRepository.Object);
        }

        [Test]
        public void Bolao_TestService_AddBolao_ShouldBeOk()
        {
            Bolao bolaoToSave = ObjectMother.GetBolaoOk(_listApostas);
            _mockRepository.Setup(br => br.Save(bolaoToSave)).Returns(bolaoToSave);


            Action comparation = () => _service.Add(bolaoToSave);

            comparation.Should().NotThrow();
            _mockRepository.Verify(br => br.Save(bolaoToSave));
        }

        [Test]
        public void Bolao_TestService_AddBolao_NoAamountOfBets_ShouldBeFail()
        {
            Bolao bolaoToSave = ObjectMother.GetBolao(_listApostas);
            bolaoToSave.QtdApostas = 0;
            _mockRepository.Setup(br => br.Save(bolaoToSave)).Returns(bolaoToSave);


            Action comparation = () => _service.Add(bolaoToSave);

            comparation.Should().Throw<BolaoNoAmountOfBetsException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Bolao_TestService_UpdateBolao_ShouldBeOk()
        {
            Bolao bolaoToUpdate = ObjectMother.GetBolaoOk(_listApostas);
            bolaoToUpdate.id = 1;
            _mockRepository.Setup(br => br.Update(bolaoToUpdate)).Returns(bolaoToUpdate);


            Action comparation = () => _service.Update(bolaoToUpdate);

            comparation.Should().NotThrow();
            _mockRepository.Verify(br => br.Update(bolaoToUpdate));
        }

        [Test]
        public void Bolao_TestService_UpdateBolao_InvalidId_ShouldBeFail()
        {
            Bolao bolaoToUpdate = ObjectMother.GetBolaoOk(_listApostas);
            bolaoToUpdate.id = -1;
            _mockRepository.Setup(br => br.Update(bolaoToUpdate)).Returns(bolaoToUpdate);

            Action comparation = () => _service.Update(bolaoToUpdate);
            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Bolao_TestService_UpdateBolao_NoAamountOfBets_ShouldBeFail()
        {
            Bolao bolaoToUpdate = ObjectMother.GetBolaoOk(_listApostas);
            bolaoToUpdate.id = 1;
            bolaoToUpdate.QtdApostas = 0;
            _mockRepository.Setup(br => br.Update(bolaoToUpdate)).Returns(bolaoToUpdate);

            Action comparation = () => _service.Update(bolaoToUpdate);
            comparation.Should().Throw<BolaoNoAmountOfBetsException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Bolao_TestService_GetBolao_ShouldBeOK()
        {
            Bolao bolaoToFind = ObjectMother.GetBolaoOk(_listApostas);
            bolaoToFind.id = 1;
            _mockRepository.Setup(br => br.Get(bolaoToFind.id)).Returns(bolaoToFind);


            Action comparation = () => _service.Get(bolaoToFind.id);

            comparation.Should().NotThrow();
            _mockRepository.Verify(br => br.Get(bolaoToFind.id));
        }

        [Test]
        public void Bolao_TestService_GetBolao_InvalidId_ShouldBeFail()
        {
            Bolao bolaoToFind = ObjectMother.GetBolaoOk(_listApostas);
            bolaoToFind.id = -1;
            _mockRepository.Setup(br => br.Update(bolaoToFind)).Returns(bolaoToFind);

            Action comparation = () => _service.Get(bolaoToFind.id);
            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Bolao_TestService_GetBolao_ShouldBeNull()
        {
            Bolao bolaoToFind = ObjectMother.GetBolaoOk(_listApostas);
            bolaoToFind.id = 1;
            _mockRepository.Setup(pr => pr.Get(bolaoToFind.id));

            var resultadoEncontrado = _service.Get(bolaoToFind.id);

            resultadoEncontrado.Should().BeNull();
            _mockRepository.Verify(br => br.Get(bolaoToFind.id));
        }

        [Test]
        public void Bolao_TestService_GetAll_ShouldBeOK()
        {
            Bolao bolaoFinded = ObjectMother.GetBolaoOk(_listApostas);

            _mockRepository.Setup(pr => pr.GetAll()).Returns(new List<Bolao> { bolaoFinded });

            IEnumerable<Bolao> resultadoEncontrado = _service.GetAll();

            resultadoEncontrado.Should().BeEquivalentTo(new List<Bolao> { bolaoFinded });
            _mockRepository.Verify(pr => pr.GetAll());
        }

        [Test]
        public void Bolao_TestService_GetAll_ShouldBeNull()
        {
            _mockRepository.Setup(pr => pr.GetAll());

            IEnumerable<Bolao> resultadoEncontrado = _service.GetAll();

            resultadoEncontrado.Should().BeNull();
            _mockRepository.Verify(br => br.GetAll());
        }

        //Verificar os Deletes...
        [Test]
        public void Bolao_TestService_DeleteBolao_ShouldBeOK()
        {
            Bolao bolaoDelete = ObjectMother.GetBolaoOk(_listApostas);
            bolaoDelete.id = 1;
            _mockRepository.Setup(pr => pr.Delete(bolaoDelete));

            _service.Delete(bolaoDelete);

            _mockRepository.Verify(br => br.Delete(bolaoDelete));
        }

        [Test]
        public void Bolao_TestService_DeleteBolao_InvalidId_ShouldBeFail()
        {
            Bolao bolaoDelete = ObjectMother.GetBolaoOk(_listApostas);
            bolaoDelete.id = -1;
            _mockRepository.Setup(pr => pr.Delete(bolaoDelete));

            Action comparation = () => _service.Delete(bolaoDelete);

            comparation.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

    }
}
