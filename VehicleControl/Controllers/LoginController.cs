using Microsoft.AspNetCore.Mvc;
using System.Net;
using VehicleControl.Auth;
using VehicleControl.Business.Interface;
using VehicleControl.Controllers.Base;
using VehicleControl.CrossCutting.DTO.Base;
using VehicleControl.CrossCutting.DTO.Login;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.CrossCutting.Helper;
using VehicleControl.Domain;

namespace VehicleControl.Controllers
{
    [Route("api/v1/login")]
    public class LoginController : BaseController<User, UserFilter, LoginDTO, LoginDTO, BaseUpdateDTO>
    {
        private readonly IUserService _userService;

        public LoginController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Login([FromBody] LoginDTO dto)
        {
            var login = _userService.Login(dto.Login, EncryptHelper.EncryptPassword(dto.Password));
            var token = UserManagement.RegisterUser(login);

            return Ok(token);
        }
    }
}
