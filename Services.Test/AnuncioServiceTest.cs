using NUnit.Framework;
using System;
using System.Linq;
using VehicleControl.Business;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Data.Repository;
using VehicleControl.Domain;
using VehicleControl.Mapper;

namespace Services.Test
{
    public class AnuncioServiceTest
    {
        private IAnuncioService _anuncioService;
        private IAnuncioRepository _anuncioRepository;
        private TestHelper _testHelper;
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            MapperConfig.RegisterMappings();

            _dataContext = new DataContext();
            _anuncioRepository = new AnuncioRepository(_dataContext);
            _anuncioService = new AnuncioService(_anuncioRepository);
            _testHelper = new TestHelper(_dataContext);

            _dataContext.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Database.RollbackTransaction();
        }

        [Test]
        public void Deve_inserir_registro_de_anuncio_corretamente()
        {
            var response = _testHelper.InsertAnuncio();
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_retornar_anuncios_corretamente()
        {
            var anuncioGuid = _testHelper.InsertAnuncio();
            Assert.IsTrue(anuncioGuid != Guid.Empty);

            var response = _anuncioService.Find(anuncioGuid);
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_atualizar_anuncios_corretamente()
        {
            var anuncioGuid = _testHelper.InsertAnuncio();
            Assert.IsTrue(anuncioGuid != Guid.Empty);

            var anuncio = _anuncioService.Find(anuncioGuid);
            var version = anuncio.Version;
            var dto = _testHelper.UpdateAnuncioDTO(anuncio);
            var response = _anuncioService.Update(MapperHelper.Map<AnuncioUpdateDTO, Anuncio>(dto));

            Assert.IsTrue(response.Version > version);
        }

        [Test]
        public void Deve_remover_anuncios_corretamente()
        {
            var anuncioGuid = _testHelper.InsertAnuncio();
            var anuncio = _anuncioService.Find(anuncioGuid);

            Assert.IsNotNull(anuncio);

            _anuncioService.Remove(anuncio.Id);

            var response = _anuncioService.GetAll(new AnuncioFilter("", null, null)).FirstOrDefault(f => f.Id.Equals(anuncio.Id));

            Assert.IsNull(response);
        }
    }
}
