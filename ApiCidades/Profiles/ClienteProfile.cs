using ApiCidades.Data.Dtos;
using ApiCidades.Models;
using AutoMapper;

namespace ApiCidades.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<Cliente, ClienteReadDto>();
            CreateMap<ClienteUpdateDto, Cliente>();
        }
    }
}
