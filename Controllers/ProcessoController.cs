using ApiGestaoProcessos.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Entities;
using ApiGestaoProcessos.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiGestaoProcessos.Controllers
{
    [Route("processos")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {

        private readonly ProcessoService _service;
        public ProcessoController(ProcessoService service)
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
            var processo = await _service.FindById(id);
            if (processo is null)
                return NotFound(new { Mensagem = $"Processo {id} não encontrado" });
            return Ok(processo);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcessoDto novoProcesso)
        {
            var processo = await _service.Create(novoProcesso);
            return CreatedAtAction(nameof(GetById), new { id = processo.Id }, processo);
        }
    }

}

        /*
        private readonly AppDbContext _context;

        public ProcessoController(AppDbContext context)
        {
            _context = context;
        }

    //Get: /processos - lista dos processos
        [HttpGet]
        
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaProcessos = await _context.Processos.ToListAsync();
                return Ok(listaProcessos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        //get: processos buscar ID
        [HttpGet("{id}")]
       
        public async Task <IActionResult> GetById(int id)
        {
            try
            {
                var processo = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);

                if (processo is null)
                {
                    return NotFound(new { Mensagem = $"Processo {id} não encontrado" });
                }
                return Ok(processo);
            } 
            catch
            {
                return Problem("Ocorreram erros ao buscar o processo");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcessoDto novoProcesso)
        {

            try
            {
                //ProcessoDto.Lista.Add(novoProcesso);
                var processo = new Processo()
                {
                    Numero = novoProcesso.Numero,
                    Data = novoProcesso.Data,
                    Interessado = novoProcesso.Interessado,
                    Assunto = novoProcesso.Assunto,
                    Descricao = novoProcesso.Descricao
                };

                await _context.Processos.AddAsync(processo);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = processo.Id }, novoProcesso);
            } 
            catch
            {
                return Problem("Ocorreram erros ao buscar o processo");
            }
        }
        
        //PUT /processo/{id} - atualiza um processo existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProcessoUpdateDto processoAtualizado)
        {
            try
            {
                var processoExistente = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);
                if (processoExistente is null)
                {
                    return NotFound(new { Mensagem = $"Erro, nao foi possivel atualizar os dados fih" });
                }
                processoExistente.Numero = processoAtualizado.Numero;
                processoExistente.Data = processoAtualizado.Data;
                processoExistente.Interessado = processoAtualizado.Interessado;
                processoExistente.Assunto = processoAtualizado.Assunto;
                processoExistente.Descricao = processoAtualizado.Descricao;

                if (processoAtualizado.Situacao is not null)
                {
                    processoExistente.Situacao = processoAtualizado.Situacao;
                }
                await _context.SaveChangesAsync();
                return NoContent();
            } catch
            {
                return Problem("Erro, nao foi possivel atualizar os dados fih");
            }
        }

        
        // DELETE: /processos/{id} - remove um processo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var processoExistente = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);
                if (processoExistente is null)
                {
                    return NotFound(new { Mensagem = $"Processo não encontrado para deletar" });
                }
                _context.Processos.Remove(processoExistente);
                await _context.SaveChangesAsync();

                return NoContent();
            } 
            catch
            {
                return Problem("Processo não encontrado");
            }
        }
        
        
    }
    */
   

