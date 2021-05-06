using System;
using Template.Domain.DTOs.Response;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Queries
{
    public interface IUsuarioQuery
    {
        Task<List<ResponseUsuarioDto>> GetAll();

    }
}
