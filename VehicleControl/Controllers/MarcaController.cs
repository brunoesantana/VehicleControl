using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using VehicleControl.Auth;
using VehicleControl.Business.Interface;
using VehicleControl.Controllers.Base;
using VehicleControl.CrossCutting.DTO.Marca;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Domain;

namespace VehicleControl.Controllers
{
    public class MarcaController : BaseController<Marca, MarcaFilter, MarcaDTO, MarcaInsertDTO, MarcaUpdateDTO>
    {
        public MarcaController(IMarcaService marcaService) : base(marcaService)
        {
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult GetAll([FromBody] MarcaFilter filter)
        {
            return base.GetAll(filter);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Get(Guid id)
        {
            return base.Find(id);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Add([FromBody] MarcaInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] MarcaUpdateDTO model)
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
