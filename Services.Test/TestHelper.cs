using Services.Test.Mock;
using System;
using VehicleControl.Business;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.DTO.Modelo;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Data.Repository;
using VehicleControl.Domain;
using VehicleControl.Mapper;

namespace Services.Test
{
    public class TestHelper
    {
        private IUserService _userService;
        private IUserRepository _userRepository;
        private IMarcaService _marcaService;
        private IMarcaRepository _marcaRepository;
        private IModeloService _modeloService;
        private IModeloRepository _modeloRepository;
        private IAnuncioService _anuncioService;
        private IAnuncioRepository _anuncioRepository;
        private MockBuilder _mockBuilder;

        public TestHelper(DataContext context)
        {
            MapperConfig.RegisterMappings();

            _userRepository = new UserRepository(context);
            _userService = new UserService(_userRepository);

            _marcaRepository = new MarcaRepository(context);
            _marcaService = new MarcaService(_marcaRepository);

            _modeloRepository = new ModeloRepository(context);
            _modeloService = new ModeloService(_modeloRepository);

            _anuncioRepository = new AnuncioRepository(context);
            _anuncioService = new AnuncioService(_anuncioRepository);

            _mockBuilder = new MockBuilder();
        }

        public Guid InsertUser()
        {
            var dto = GetUserInsertDTO();
            return _userService.Create(MapperHelper.Map<UserInsertDTO, User>(dto));
        }

        private UserInsertDTO GetUserInsertDTO()
        {
            return _mockBuilder.BuilderUserInsertDTO();
        }

        public UserUpdateDTO UpdateUserDTO(User user)
        {
            return _mockBuilder.BuilderUpdateUserDTO(user);
        }

        public Guid InsertMarca()
        {
            var dto = GetMarcaInsertDTO();
            return _marcaService.Create(MapperHelper.Map<MarcaInsertDTO, Marca>(dto));
        }

        private MarcaInsertDTO GetMarcaInsertDTO()
        {
            return _mockBuilder.BuildMarcaInsertDTO();
        }

        public MarcaUpdateDTO UpdateMarcaDTO(Marca marca)
        {
            return _mockBuilder.BuilderUpdateMarcaDTO(marca);
        }

        public Guid InsertModelo()
        {
            var dto = GetModeloInsertDTO();
            return _modeloService.Create(MapperHelper.Map<ModeloInsertDTO, Modelo>(dto));
        }

        private ModeloInsertDTO GetModeloInsertDTO()
        {
            return _mockBuilder.BuilderModeloInsertDTO();
        }

        public ModeloUpdateDTO UpdateModeloDTO(Modelo modelo)
        {
            return _mockBuilder.BuilderUpdateModeloDTO(modelo);
        }

        public Guid InsertAnuncio()
        {
            var marcaKey = InsertMarca();
            var modeloKey = InsertModelo();
            var dto = GetAnuncioInsertDTO(marcaKey, modeloKey);
            return _anuncioService.Create(MapperHelper.Map<AnuncioInsertDTO, Anuncio>(dto));
        }

        public AnuncioInsertDTO GetAnuncioInsertDTO(Guid marcaKey, Guid modeloKey)
        {
            return _mockBuilder.BuilderAnuncioInsertDTO(marcaKey, modeloKey);
        }

        public AnuncioUpdateDTO UpdateAnuncioDTO(Anuncio anuncio)
        {
            return _mockBuilder.BuilderUpdateAnuncioDTO(anuncio);
        }
    }
}
