using AutoMapper;
using Template.Domain.Commands;
using Template.Domain.DTOs.Request;
using Template.Domain.DTOs.Response;
using Template.Domain.Entities;
using Template.Domain.Queries;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericsRepository _repository;
        private readonly IUsuarioQuery _query;
        private readonly IMapper _mapper;

        public UsuarioService (IGenericsRepository repository, IUsuarioQuery query, IMapper mapper)
        {
            _repository = repository;
            _query = query;
            _mapper = mapper;
        }
        public async Task <ResponseUsuarioDto> Create(RequestUsuarioDto request)
        {
            var u = _mapper.Map<Usuario>(request);
            await _repository.Add(u);
            return _mapper.Map<ResponseUsuarioDto>(u);
        }
        public async Task<List<ResponseUsuarioDto>>GetAll()
        {
            return await _query.GetAll();
        }
    }
}
