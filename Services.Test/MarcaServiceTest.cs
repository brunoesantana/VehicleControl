using NUnit.Framework;
using System.Linq;
using VehicleControl.Business;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Data.Repository;
using VehicleControl.Domain;
using VehicleControl.Mapper;

namespace Services.Test
{
    public class MarcaServiceTest
    {
        private IMarcaService _marcaService;
        private IMarcaRepository _marcaRepository;
        private TestHelper _testHelper;
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            MapperConfig.RegisterMappings();

            _dataContext = new DataContext();
            _marcaRepository = new MarcaRepository(_dataContext);
            _marcaService = new MarcaService(_marcaRepository);
            _testHelper = new TestHelper(_dataContext);

            _dataContext.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Database.RollbackTransaction();
        }

        [Test]
        public void Deve_inserir_registro_de_marca_corretamente()
        {
            var response = _testHelper.InsertMarca();
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_retornar_marcas_corretamente()
        {
            _testHelper.InsertMarca();

            var list = _marcaService.GetAll(new MarcaFilter(""));
            Assert.IsTrue(list.Any());

            var marca = list.FirstOrDefault();
            var response = _marcaService.Find(marca.Id);
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_atualizar_marcas_corretamente()
        {
            var marcaGuid = _testHelper.InsertMarca();
            var marca = _marcaService.Find(marcaGuid);
            var version = marca.Version;
            var dto = _testHelper.UpdateMarcaDTO(marca);

            var response = _marcaService.Update(MapperHelper.Map<MarcaUpdateDTO, Marca>(dto));

            Assert.IsTrue(response.Version > version);
        }

        [Test]
        public void Deve_remover_marcas_corretamente()
        {
            var marcaGuid = _testHelper.InsertMarca();
            var marca = _marcaService.Find(marcaGuid);

            Assert.IsNotNull(marca);

            _marcaService.Remove(marca.Id);

            var response = _marcaService.Find(marca.Id);

            Assert.IsNull(response);
        }
    }
}
