using ApiGestaoProcessos.Services;
using Microsoft.AspNetCore.Mvc;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Entities;
namespace ApiGestaoProcessos.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _service;
        public ClientesController(ClientesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _service.FindAll();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clientes = await _service.FindById(id);
            if (clientes is null)
                return NotFound(new { Mensagem = $"Cliente {id} não encontrado fih" });
            return Ok(clientes);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientesDto data)
        {
            try
            {
                var clientes = await _service.Create(data);
                return Created("", clientes);
            }
            catch(Exception e)
            {
                return Problem(e.Message);
            }

        }
    }
}
