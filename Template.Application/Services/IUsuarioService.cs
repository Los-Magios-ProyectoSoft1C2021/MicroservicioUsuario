using Template.Domain.DTOs.Response;
using Template.Domain.DTOs.Request;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application.Services
{
    public interface IUsuarioService
    {
        Task<ResponseUsuarioDto> Create(RequestUsuarioDto request);
        Task<List<ResponseUsuarioDto>> GetAll();
    }
}
