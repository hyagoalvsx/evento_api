using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
using ApiGestaoProcessos.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Services
{
    public class ProcessoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProcessoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // lista todos, já convertidos para DTO de resposta.
        // projecTo traduz o mapeamento para SQL (traz só colunas usadas)

        public async Task<ICollection<ProcessoResponseDto>>FindAll()
        {
            return await _context.Processos.ProjectTo<ProcessoResponseDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        // busca por ID. retorna null quando não existe.

        public async Task<Processo?>FindById(int id)
        {
            return await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);
        }

        // cria um novo processo a partir do DTO de entrada.
        // _mapper.map faz o "de/para" (inclusive Situacao = "Aberto")

        public async Task<Processo> Create(ProcessoDto data)
        {
            var processo = _mapper.Map<Processo>(data);

            await _context.Processos.AddAsync(processo);
            await _context.SaveChangesAsync();

            return processo;
        }
       
    }
}
