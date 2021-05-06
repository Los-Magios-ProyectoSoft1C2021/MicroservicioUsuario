using Template.Application.Services;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;
using Template.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController:ControllerBase
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
            return Created(uri: $"api/usuario/{createdUsuario.UsuarioId}",createdUsuario);
        }
    }
}
