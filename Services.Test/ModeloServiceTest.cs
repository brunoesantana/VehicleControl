using NUnit.Framework;
using System;
using System.Linq;
using VehicleControl.Business;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Data.Repository;
using VehicleControl.Domain;
using VehicleControl.Mapper;

namespace Services.Test
{
    public class ModeloServiceTest
    {
        private IModeloService _modeloService;
        private IModeloRepository _modeloRepository;
        private TestHelper _testHelper;
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            MapperConfig.RegisterMappings();

            _dataContext = new DataContext();
            _modeloRepository = new ModeloRepository(_dataContext);
            _modeloService = new ModeloService(_modeloRepository);
            _testHelper = new TestHelper(_dataContext);

            _dataContext.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Database.RollbackTransaction();
        }

        [Test]
        public void Deve_inserir_registro_de_modelo_corretamente()
        {
            var response = _testHelper.InsertModelo();
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_retornar_modelos_corretamente()
        {
            var modeloGuid = _testHelper.InsertModelo();
            Assert.IsTrue(modeloGuid != Guid.Empty);

            var response = _modeloService.Find(modeloGuid);
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_atualizar_modelos_corretamente()
        {
            var modeloGuid = _testHelper.InsertModelo();
            Assert.IsTrue(modeloGuid != Guid.Empty);

            var modelo = _modeloService.Find(modeloGuid);
            var version = modelo.Version;
            var dto = _testHelper.UpdateModeloDTO(modelo);
            var response = _modeloService.Update(MapperHelper.Map<ModeloUpdateDTO, Modelo>(dto));

            Assert.IsTrue(response.Version > version);
        }

        [Test]
        public void Deve_remover_modelos_corretamente()
        {
            var modeloGuid = _testHelper.InsertModelo();
            var modelo = _modeloService.Find(modeloGuid);

            Assert.IsNotNull(modelo);

            _modeloService.Remove(modelo.Id);

            var response = _modeloService.GetAll(new ModeloFilter("")).FirstOrDefault(f => f.Id.Equals(modelo.Id));

            Assert.IsNull(response);
        }
    }
}
