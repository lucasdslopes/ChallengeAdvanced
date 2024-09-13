using InovaXSprint.Models;
using InovaXSprint.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InovaXSprint.Controllers
{
    [Route("api/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IRepository<Endereco> _enderecoRepository;

        public EnderecoController(IRepository<Endereco> enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            _enderecoRepository.Add(endereco);
            return CreatedAtAction(nameof(GetAll), new { id = endereco.IdEndereco }, endereco);
        }

        [HttpGet("v1/endereco")]
        [ProducesResponseType(typeof(List<Endereco>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var enderecos = _enderecoRepository.GetAll();
            return Ok(enderecos);
        }

        [HttpPatch("v1/endereco")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Endereco endereco)
        {
            _enderecoRepository.Update(endereco);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Endereco endereco)
        {
            _enderecoRepository.Delete(endereco);
            return Ok();
        }

    }
}
