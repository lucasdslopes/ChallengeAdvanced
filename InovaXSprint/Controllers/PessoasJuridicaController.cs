using InovaXSprint.Models;
using InovaXSprint.Repository; 
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InovaXSprint.Controllers
{
    [Route("api/pessoasJuridica")]
    [ApiController]
    public class PessoasJuridicaController : ControllerBase
    {
        private readonly IRepository<PessoaJuridica> _pessoaJuridicaRepository;

        public PessoasJuridicaController(IRepository<PessoaJuridica> pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] PessoaJuridica pessoaJuridica)
        {
            _pessoaJuridicaRepository.Add(pessoaJuridica);
            return CreatedAtAction(nameof(GetAll), new { id = pessoaJuridica.Id }, pessoaJuridica);
        }

        [HttpGet("v1/pessoaJuridica")]
        [ProducesResponseType(typeof(List<PessoaJuridica>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var pessoasJuridicas = _pessoaJuridicaRepository.GetAll();
            return Ok(pessoasJuridicas);
        }

        [HttpPatch("v1/pessoaJuridica")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] PessoaJuridica pessoaJuridica)
        {
            _pessoaJuridicaRepository.Update(pessoaJuridica);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] PessoaJuridica pessoaJuridica)
        {
            _pessoaJuridicaRepository.Delete(pessoaJuridica);
            return Ok();
        }
    }
}
