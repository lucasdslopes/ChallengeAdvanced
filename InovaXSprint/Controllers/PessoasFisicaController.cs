using InovaXSprint.Models;
using InovaXSprint.Repository; 
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace InovaXSprint.Controllers
{
    [Route("api/pessoasFisica")]
    [ApiController]
    public class PessoasFisicaController : ControllerBase
    {
        private readonly IRepository<PessoaFisica> _pessoaFisicaRepository;

        public PessoasFisicaController(IRepository<PessoaFisica> pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] PessoaFisica pessoaFisica)
        {
            _pessoaFisicaRepository.Add(pessoaFisica);
            return CreatedAtAction(nameof(GetAll), new { id = pessoaFisica.Id }, pessoaFisica);
        }

        [HttpGet("v1/pessoaFisica")]
        [ProducesResponseType(typeof(List<PessoaFisica>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var pessoasFisicas = _pessoaFisicaRepository.GetAll();
            return Ok(pessoasFisicas);
        }

        [HttpPatch("v1/pessoaFisica")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] PessoaFisica pessoaFisica)
        {
            _pessoaFisicaRepository.Update(pessoaFisica);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] PessoaFisica pessoaFisica)
        {
            _pessoaFisicaRepository.Delete(pessoaFisica);
            return Ok();
        }
    }
}
