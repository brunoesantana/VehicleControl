using NUnit.Framework;
using System.Linq;
using VehicleControl.Business;
using VehicleControl.Business.Interface;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Data.Repository;
using VehicleControl.Domain;
using VehicleControl.Mapper;

namespace Services.Test
{
    public class UserServiceTest
    {
        private const string SENHA = "12345";

        private IUserService _userService;
        private IUserRepository _userRepository;
        private TestHelper _testHelper;
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            MapperConfig.RegisterMappings();

            _dataContext = new DataContext();
            _userRepository = new UserRepository(_dataContext);
            _userService = new UserService(_userRepository);
            _testHelper = new TestHelper(_dataContext);

            _dataContext.Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Database.RollbackTransaction();
        }

        [Test]
        public void Deve_inserir_registro_de_usuario_corretamente()
        {
            var response = _testHelper.InsertUser();
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_retornar_usuarios_corretamente()
        {
            _testHelper.InsertUser();

            var list = _userService.GetAll(new UserFilter());
            Assert.IsTrue(list.Any());

            var user = list.FirstOrDefault();
            var response = _userService.Find(user.Id);
            Assert.IsNotNull(response);
        }

        [Test]
        public void Deve_atualizar_usuarios_corretamente()
        {
            var userGuid = _testHelper.InsertUser();
            var user = _userService.Find(userGuid);
            var version = user.Version;
            var dto = _testHelper.UpdateUserDTO(user);

            var response = _userService.Update(MapperHelper.Map<UserUpdateDTO, User>(dto));

            Assert.IsTrue(response.Version > version);
        }

        [Test]
        public void Deve_remover_usuarios_corretamente()
        {
            var userGuid = _testHelper.InsertUser();
            var book = _userService.Find(userGuid);

            Assert.IsNotNull(book);

            _userService.Remove(book.Id);

            var response = _userService.Find(book.Id);

            Assert.IsNull(response);
        }

        [Test]
        public void Deve_logar_corretamente()
        {
            _testHelper.InsertUser();

            var user = _userService.GetAll(new UserFilter()).FirstOrDefault(f => f.Active);
            var userResponse = _userService.Login(user.UserName, EncryptHelper.EncryptPassword(SENHA));

            Assert.IsNotNull(userResponse);
        }
    }
}
