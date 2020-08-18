using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using VehicleControl.Auth;
using VehicleControl.Business.Interface;
using VehicleControl.Controllers.Base;
using VehicleControl.CrossCutting.DTO.User;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Domain;

namespace VehicleControl.Controllers
{
    [Route("api/v1/users")]
    public class UserController : BaseController<User, UserFilter, UserDTO, UserInsertDTO, UserUpdateDTO>
    {
        public UserController(IUserService userService) : base(userService)
        {
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public ActionResult GetAll(string term)
        {
            var filter = new UserFilter(term);
            return base.GetAll(filter);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public ActionResult Get(Guid id)
        {
            return base.Find(id);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Add([FromBody] UserInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] UserUpdateDTO model)
        {
            return base.Update(id, model);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}
