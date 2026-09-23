using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
using ApiGestaoProcessos.Entities;
using AutoMapper;

namespace ApiGestaoProcessos.Profiles
{
    public class ProcessoProfile : Profile
    {
        public ProcessoProfile()
        {
            // entrada: ProcessoDto -> Processo
            // situação começa sempre como "aberto"
            CreateMap<ProcessoDto, Processo>().ForMember(
            dest => dest.Situacao,
            opt => opt.MapFrom(src => "Aberto"));

            // entrada: ProcessoUpdateDto -> Processo (atualização)
            CreateMap<ProcessoUpdateDto, Processo>();
            // saída: Processo -> ProcessoResponseDto
            CreateMap<Processo, ProcessoResponseDto>();
        }
    }
}
