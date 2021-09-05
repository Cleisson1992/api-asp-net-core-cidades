using ApiCidades.Data.Dtos;
using ApiCidades.Domain.Entities;
using AutoMapper;

namespace ApiCidades.Mappers
{
    public class CidadeMapper : Profile
    {
        public CidadeMapper()
        {
            CreateMap<CidadeCreateDto, Cidade>();
            CreateMap<Cidade, CidadeReadDto>();
        }
    }
}
