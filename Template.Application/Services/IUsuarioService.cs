using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;

namespace Template.Application.Services
{
    public interface IUsuarioService
    {
        Task<ResponseUsuarioDto> Create(RequestUsuarioDto request);
        Task<List<ResponseUsuarioDto>> GetAll();
        Task<ResponseUsuarioDto> GetById(int usuarioId);
        Task<string> AuthenticateUser(RequestLoginDto request);
    }
}
