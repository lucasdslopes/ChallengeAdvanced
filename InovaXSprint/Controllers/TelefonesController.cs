using InovaXSprint.Models;
using InovaXSprint.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace InovaXSprint.Controllers
{
    [Route("api/telefones")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly IRepository<Telefone> _telefoneRepository;

        public TelefonesController(IRepository<Telefone> telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Telefone telefone)
        {
            _telefoneRepository.Add(telefone);
            return CreatedAtAction(nameof(GetAll), new { id = telefone.TelefoneId }, telefone);
        }

        [HttpGet("v1/telefone")]
        [ProducesResponseType(typeof(List<Telefone>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var telefones = _telefoneRepository.GetAll();
            return Ok(telefones);
        }

        [HttpPatch("v1/telefone")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Telefone telefone)
        {
            _telefoneRepository.Update(telefone);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Telefone telefone)
        {
            _telefoneRepository.Delete(telefone);
            return Ok();
        }
    }
}
