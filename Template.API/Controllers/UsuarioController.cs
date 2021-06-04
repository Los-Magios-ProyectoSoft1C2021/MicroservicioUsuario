using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Services;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;

namespace Template.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseUsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult> PostUsuario(RequestUsuarioDto usuario)
        {
            var createdUsuario = await _usuarioService.Create(usuario);
            if (createdUsuario == null)
                throw new Exception();
            return Created(uri: $"api/usuario/{createdUsuario.UsuarioId}", createdUsuario);
        }
    }
}
