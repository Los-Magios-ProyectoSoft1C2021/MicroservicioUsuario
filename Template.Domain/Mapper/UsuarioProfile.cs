using AutoMapper;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;
using Template.Domain.Entities;

namespace Template.Domain.Mapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, RequestUsuarioDto>();
            CreateMap<RequestUsuarioDto, Usuario>();

            CreateMap<ResponseUsuarioDto, Usuario>();
            CreateMap<Usuario, ResponseUsuarioDto>();
        }

    }
}
