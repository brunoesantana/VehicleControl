using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using VehicleControl.Auth;
using VehicleControl.Business.Interface;
using VehicleControl.Controllers.Base;
using VehicleControl.CrossCutting.DTO.Anuncio;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Domain;

namespace VehicleControl.Controllers
{
    [Route("api/v1/anuncios")]
    public class AnuncioController : BaseController<Anuncio, AnuncioFilter, AnuncioDTO, AnuncioInsertDTO, AnuncioUpdateDTO>
    {
        public AnuncioController(IAnuncioService anuncioService) : base(anuncioService)
        {
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult GetAll(string term, DateTime? initialDate, DateTime? finalDate)
        {
            var filter = new AnuncioFilter(term, initialDate, finalDate);
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
        public new ActionResult Add([FromBody] AnuncioInsertDTO model)
        {
            return base.Add(model);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [TokenRequestValidation]
        public new ActionResult Update([FromRoute] Guid id, [FromBody] AnuncioUpdateDTO model)
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
