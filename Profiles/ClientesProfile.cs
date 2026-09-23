using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
using ApiGestaoProcessos.Entities;
using AutoMapper;

namespace ApiGestaoProcessos.Profiles
{
    public class ClientesProfile : Profile
    {
    public ClientesProfile()
    {
            CreateMap<ClientesDto, Clientes>();

            CreateMap<Clientes, ClientesResponseDto>();
    }
    }
}
