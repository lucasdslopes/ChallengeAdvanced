
using InovaXSprint.Models;
using InovaXSprint.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InovaXSprint.Controllers
{
    [Route("api/distribuidores")]
    [ApiController]
    public class DistribuidoresController : ControllerBase
    {
        private readonly IRepository<Distribuidor> _distribuidorRepository;

        public DistribuidoresController(IRepository<Distribuidor> distribuidorRepository)
        {
            _distribuidorRepository = distribuidorRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Distribuidor distribuidor)
        {
            if (distribuidor == null || string.IsNullOrEmpty(distribuidor.Tipo))
            {
                return BadRequest("The Tipo field is required.");
            }

            _distribuidorRepository.Add(distribuidor);
            return CreatedAtAction(nameof(GetAll), new { id = distribuidor.Id }, distribuidor);
        }

        [HttpGet("v1/distribuidor")]
        [ProducesResponseType(typeof(List<Distribuidor>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var distribuidores = _distribuidorRepository.GetAll();
            return Ok(distribuidores);
        }

        [HttpPatch("v1/distribuidor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Distribuidor distribuidor)
        {
            if (distribuidor == null || string.IsNullOrEmpty(distribuidor.Tipo))
            {
                return BadRequest("The Tipo field is required.");
            }

            _distribuidorRepository.Update(distribuidor);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Distribuidor distribuidor)
        {
            _distribuidorRepository.Delete(distribuidor);
            return Ok();
        }
    }
}
