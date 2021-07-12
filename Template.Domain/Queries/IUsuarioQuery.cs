using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Domain.DTOs.Response;

namespace Template.Domain.Queries
{
    public interface IUsuarioQuery
    {
        Task<List<ResponseUsuarioDto>> GetAll();
        Task<ResponseUsuarioDto> GetById(int usuarioId);
        Task<ResponseLoginDto> GetUsuarioLogin(string nombreUsuario, string contraseña);
    }
}
