using ApiCidades.Data.Dtos;
using ApiCidades.Models;
using AutoMapper;

namespace ApiCidades.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<CidadeCreateDto, Cidade>();
            CreateMap<Cidade, CidadeReadDto>();
        }
    }
}
