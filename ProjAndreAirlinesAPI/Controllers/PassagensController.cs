using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirlinesAPI.Data;
using ProjAndreAirlinesAPI.DTO;
using ProjAndreAirlinesAPI.Model;
using ProjAndreAirlinesAPI.Service;

namespace ProjAndreAirlinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagensController : ControllerBase
    {
        private readonly ProjAndreAirlinesAPIContext _context;

        public PassagensController(ProjAndreAirlinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Passagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.Include(passsagem => passsagem.Voo.Aeronave)
                                          .Include(passsagem => passsagem.Voo.Origem.Endereco)
                                          .Include(passsagem => passsagem.Voo.Destino.Endereco)
                                          .Include(passsagem => passsagem.Classe)
                                          .Include(passsagem => passsagem.Passageiro.Endereco)
                                          .ToListAsync();
        }

        // GET: api/Passagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem.Include(passsagem => passsagem.Voo.Aeronave)
                                          .Include(passsagem => passsagem.Voo.Origem.Endereco)
                                          .Include(passsagem => passsagem.Voo.Destino.Endereco)
                                          .Include(passsagem => passsagem.Classe)
                                          .Include(passsagem => passsagem.Passageiro.Endereco)
                                          .Where(passsagem => passsagem.Id == id)
                                          .FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Passagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(PassagemDTO passagem)
        {
            Voo voo = await _context.Voo.Where(voo => voo.Id == passagem.VooId)
                                        .FirstOrDefaultAsync();

            if (voo == null)
                throw new Exception("Voo não encontrado!");


            var passageiro = await _context.Passageiro.Where(passageiro => passageiro.Cpf == passagem.PassageiroCpf)
                                                      .FirstOrDefaultAsync();

            if (passageiro == null)
                throw new Exception("Passageiro não encontrado!");


            var classe = await _context.Classe.Where(classe => classe.Id == passagem.ClasseId)
                                              .FirstOrDefaultAsync();

            if (classe == null)
                throw new Exception("Classe não encontrada!");

            _context.Passagem.Add(new Passagem(passagem.VooId, passagem.PassageiroCpf, passagem.ClasseId, passagem.Valor, passagem.DataCadastro));

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);

            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}
