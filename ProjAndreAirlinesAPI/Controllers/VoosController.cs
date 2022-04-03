using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirlinesAPI.Data;
using ProjAndreAirlinesAPI.Service;
using ProjAndreAirlinesAPI.Model;

namespace ProjAndreAirlinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly ProjAndreAirlinesAPIContext _context;

        public VoosController(ProjAndreAirlinesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Voos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetVoo()
        {
            return await _context.Voo.Include(voo => voo.Aeronave)
                                     .Include(voo => voo.Origem.Endereco)
                                     .Include(voo => voo.Destino.Endereco)
                                     .ToListAsync();
        }

        // GET: api/Voos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {
            var voo = await _context.Voo.Include(voo => voo.Aeronave)
                                        .Include(voo => voo.Origem.Endereco)
                                        .Include(voo => voo.Destino.Endereco)
                                        .Where(voo => voo.Id == id)
                                        .FirstOrDefaultAsync();

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voo>> PostVoo(Voo voo)
        {
            Endereco endereco;

            var aeronave = await _context.Aeronave.Where(a => a.Id == voo.Aeronave.Id)
                                                  .FirstOrDefaultAsync();

            voo.Aeronave = aeronave ?? voo.Aeronave;

            var aeroportoOrigem = await _context.Aeroporto.Where(ao => ao.Sigla == voo.Origem.Sigla)
                                                          .FirstOrDefaultAsync();

            if (aeroportoOrigem != null)
                voo.Origem = aeroportoOrigem;
            else if ((endereco = await ViaCepService.ConsultarCep(voo.Origem.Endereco.Cep)) != null)
            {
                endereco.Numero = voo.Origem.Endereco.Numero;
                voo.Origem.Endereco = endereco;
            }

            var aeroportoDestino = await _context.Aeroporto.Where(ad => ad.Sigla == voo.Destino.Sigla)
                                                           .FirstOrDefaultAsync();

            if (aeroportoDestino != null)
                voo.Destino = aeroportoDestino;
            else if ((endereco = await ViaCepService.ConsultarCep(voo.Destino.Endereco.Cep)) != null)
            {
                endereco.Numero = voo.Destino.Endereco.Numero;
                voo.Destino.Endereco = endereco;
            }


            _context.Voo.Add(voo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VooExists(voo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVoo", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoo(string id)
        {
            var voo = await _context.Voo.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voo.Remove(voo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VooExists(int id)
        {
            return _context.Voo.Any(e => e.Id == id);
        }
    }
}
