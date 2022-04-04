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
using ProjAndreAirlinesAPI.DTO;

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
        public async Task<ActionResult<Voo>> PostVoo(VooDTO voo)
        {
            var aeronave = await _context.Aeronave.Where(aeronave => aeronave.Id.Equals(voo.AeronaveId))
                                                        .FirstOrDefaultAsync();

            if (aeronave == null)
                throw new Exception("Aeronave não encontrada!");


            var origem = await _context.Aeroporto.Where(origem => origem.Sigla.Equals(voo.OrigemSigla))
                                                        .FirstOrDefaultAsync();

            if (origem == null)
                throw new Exception("Aeroporto de origem não encontrado!");

            var destino = await _context.Aeroporto.Where(destino => destino.Sigla.Equals(voo.DestinoSigla))
                                                        .FirstOrDefaultAsync();

            if (destino == null)
                throw new Exception("Aeroporto de destino não encontrado!");


            _context.Voo.Add(new Voo(voo.OrigemSigla, voo.DestinoSigla, voo.AeronaveId, voo.HorarioEmbarque, voo.HorarioDesembarque));

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
