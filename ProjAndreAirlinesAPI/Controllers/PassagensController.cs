using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirlinesAPI.Data;
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
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            Endereco endereco;

            Voo voo = await _context.Voo.Where(voo => voo.Id == passagem.Voo.Id)
                                        .FirstOrDefaultAsync();

            passagem.Voo = voo ?? passagem.Voo;


            Aeroporto aeroportoOrigem = await _context.Aeroporto.Where(aeroporto => aeroporto.Sigla == passagem.Voo.Origem.Sigla)
                                        .FirstOrDefaultAsync();

            passagem.Voo.Origem = aeroportoOrigem ?? passagem.Voo.Origem;

            Aeroporto aeroportoDestino = await _context.Aeroporto.Where(aeroporto => aeroporto.Sigla == passagem.Voo.Destino.Sigla)
                                        .FirstOrDefaultAsync();
            passagem.Voo.Destino = aeroportoDestino ?? passagem.Voo.Destino;

            var passageiro = await _context.Passageiro.Where(passageiro => passageiro.Cpf == passagem.Passageiro.Cpf)
                                                      .FirstOrDefaultAsync();



            if (passageiro != null)
                passagem.Passageiro = passageiro;
            else if ((endereco = await ViaCepService.ConsultarCep(passagem.Passageiro.Endereco.Cep)) != null)
            {
                endereco.Cep.Replace("-", "");
                endereco.Numero = passagem.Passageiro.Endereco.Numero;
                passagem.Passageiro.Endereco = endereco;
            }

            var classe = await _context.Classe.Where(classe => classe.Id == passagem.Classe.Id)
                                              .FirstOrDefaultAsync();

            passagem.Classe = classe ?? passagem.Classe;

            _context.Passagem.Add(passagem);

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
