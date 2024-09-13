
using InovaXSprint.Models;
using InovaXSprint.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InovaXSprint.Controllers
{
    [Route("api/servicos")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly IRepository<Servico> _servicoRepository;

        public ServicosController(IRepository<Servico> servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Servico servico)
        {
            if (servico == null || string.IsNullOrEmpty(servico.Nome))
            {
                return BadRequest("The Nome field is required.");
            }

            if (servico.Distribuidores == null || !servico.Distribuidores.Any())
            {
                return BadRequest("At least one Distribuidor is required.");
            }

            _servicoRepository.Add(servico);
            return CreatedAtAction(nameof(GetAll), new { id = servico.IdServico }, servico);
        }

        [HttpGet("v1/servico")]
        [ProducesResponseType(typeof(List<Servico>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var servicos = _servicoRepository.GetAll();
            return Ok(servicos);
        }

        [HttpPatch("v1/servico")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Servico servico)
        {
            if (servico == null || string.IsNullOrEmpty(servico.Nome))
            {
                return BadRequest("The Nome field is required.");
            }

            _servicoRepository.Update(servico);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Servico servico)
        {
            _servicoRepository.Delete(servico);
            return Ok();
        }
    }
}
