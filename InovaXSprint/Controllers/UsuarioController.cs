using Microsoft.AspNetCore.Mvc;
using System.Net;
using InovaXSprint.Models;
using InovaXSprint.Repository;

namespace InovaXSprint.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public UsuarioController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
            return CreatedAtAction(nameof(GetAll), new { id = usuario.Id }, usuario);
        }

        [HttpGet("v1/usuario")]
        [ProducesResponseType(typeof(List<Usuario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpPatch("v1/usuario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Usuario usuario)
        {
            _usuarioRepository.Delete(usuario);
            return Ok();
        }
    }
}
