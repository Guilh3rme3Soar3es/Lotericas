
using Moq;
using NUnit.Framework;
using ProjetoLoteria.Application.Features.Resultados;
using ProjetoLoterica.Common.Tests.ObjectMothers;
using ProjetoLoterica.Domain.Features.Apostas;
using ProjetoLoterica.Domain.Features.Apostas.Dezenas;
using ProjetoLoterica.Domain.Features.Boloes;
using ProjetoLoterica.Domain.Features.Concursos;
using ProjetoLoterica.Domain.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLoterica.Application.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoServiceTests
    {
        private Mock<IResultadoRepository> _mockRepository;
        private ResultadoService _service;

        private Bolao _bolao;
        private Concurso _concurso;
        private List<Dezena> _listDezenas;
        private Aposta _aposta;

        [SetUp]
        public void Initialize()
        {

            _aposta = ObjectMother.GetAposta();
            _listDezenas = ObjectMother.GetListDezenas();
            _mockRepository = new Mock<IResultadoRepository>();
            _service = new ResultadoService(_mockRepository.Object);
        }

        [Test]
        public void Resultado_ServiceTests_AddResultado_ShouldBe()
        {
            Resultado resultadoToSave = ObjectMother.GetResultado();
        }
    }
}
