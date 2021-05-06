using System;
using Template.Domain.DTOs;
using Template.Domain.Entities;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;
using AutoMapper;
using System.Collections.Generic;
using System.Text;

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
