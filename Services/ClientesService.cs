using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Entities;
using ApiGestaoProcessos.Dtos.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ApiGestaoProcessos.Dtos;

namespace ApiGestaoProcessos.Services
{
    public class ClientesService(AppDbContext _context, IMapper _mapper)
    {
        public async Task<ICollection<Clientes>>FindAll()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Clientes?> FindById(int id)
        {
            
            return await _context.Clientes.FindAsync(id);
        }
        public async Task<Clientes> Create(ClientesDto data)
        {
            var clientes = _mapper.Map<Clientes>(data);

            await _context.Clientes.AddAsync(clientes);
            await _context.SaveChangesAsync();

            return clientes;
        }
    }
}
