using JwtAuthApi.Core.Interfaces;
using JwtAuthApi.Infrastructure.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JwsAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_usuarioService.GetAll());

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var usuario = _usuarioService.GetById(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (_usuarioService.ExistsByLoginOrEmail(usuario.Login, usuario.Email))
                return Conflict("Já existe um usuário com este login ou email.");

            _usuarioService.Create(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] Usuario usuario)
        {
            var existing = _usuarioService.GetById(id);
            if (existing == null) return NotFound();

            usuario.Id = id;
            _usuarioService.Update(usuario);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var existing = _usuarioService.GetById(id);
            if (existing == null) return NotFound();

            _usuarioService.Delete(id);
            return NoContent();
        }
    }
}
