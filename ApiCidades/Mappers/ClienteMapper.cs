using ApiCidades.Data.Dtos;
using ApiCidades.Domain.Entities;
using AutoMapper;

namespace ApiCidades.Profiles
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<Cliente, ClienteReadDto>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
