using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<ActionResult<List<ResponseUsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [Authorize(Policy = "AdminAndUsuarioOnly")]
        [HttpGet("id")]
        public async Task<ActionResult<ResponseUsuarioDto>> GetUsuario()
        {
            var usuario = HttpContext.User;
            var usuarioId = usuario.FindFirst("UsuarioId");

            if (usuarioId != null)
            {
                var u = await _usuarioService.GetById(int.Parse(usuarioId.Value));

                if (u != null)
                    return Ok(u);
                else
                    return NotFound();
            }

            return Unauthorized();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("id/{id:int}")]
        public async Task<ActionResult> GetUsuarioById(int id)
        {
            var u = await _usuarioService.GetById(id);

            if (u != null)
                return Ok(u);
            else
                return NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostUsuario(RequestUsuarioDto usuario)
        {
            var createdUsuario = await _usuarioService.Create(usuario);
            if (createdUsuario == null)
                return Problem(detail: "No se ha podido crear el usuario", statusCode: 500);

            var usuarioRequest = new RequestLoginDto
            { NombreUsuario = createdUsuario.NombreUsuario, Contraseña = createdUsuario.Contraseña };

            string token = await _usuarioService.AuthenticateUser(usuarioRequest);
            return (token != null)
                ? Created(uri: $"api/usuario/{createdUsuario.UsuarioId}", new ResponseTokenDto { Token = token })
                : Problem(statusCode: 500, detail: "Ha ocurrido un problema al intentar registrar el usuario.");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> PostLogin([FromBody] RequestLoginDto request)
        {
            string token = await _usuarioService.AuthenticateUser(request);
            return (token != null) ? 
                Ok(new ResponseTokenDto { Token = token }) : 
                Problem(statusCode: 401, detail: "No se ha ingresado un usuario/contraseña válido");
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("rol")]
        public ActionResult GetClaim()
        {
            var currentUser = HttpContext.User;
            var rol = currentUser.FindFirst("Rol");
            if (rol != null)
                return Ok(rol.Value);

            return NotFound("No tiene un rol");
        }
    }
}
