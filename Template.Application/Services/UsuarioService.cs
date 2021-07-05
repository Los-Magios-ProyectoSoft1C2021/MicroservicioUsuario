using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Commands;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;
using Template.Domain.Entities;
using Template.Domain.Queries;

namespace Template.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericsRepository _repository;
        private readonly IUsuarioQuery _query;
        private readonly IMapper _mapper;

        public UsuarioService(IConfiguration configuration, IGenericsRepository repository, IUsuarioQuery query, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _query = query;
            _mapper = mapper;
        }

        public async Task<ResponseUsuarioDto> Create(RequestUsuarioDto request)
        {
            var u = _mapper.Map<Usuario>(request);
            await _repository.Add(u);
            return _mapper.Map<ResponseUsuarioDto>(u);
        }
        public async Task<List<ResponseUsuarioDto>> GetAll()
        {
            return await _query.GetAll();
        }


        public async Task<string> AuthenticateUser(RequestLoginDto request)
        {
            var usuarioData = await _query.GetUsuarioLogin(request.NombreUsuario, request.Contraseña);
            return (usuarioData != null) ? GenerateJSONWebToken(usuarioData) : null;
        }

        private string GenerateJSONWebToken(ResponseLoginDto usuarioData)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("NombreUsuario", usuarioData.NombreUsuario),
                new Claim("UsuarioId", usuarioData.UsuarioId.ToString()),
                new Claim("Rol", usuarioData.Rol),
                new Claim("Email", usuarioData.Correo),
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
