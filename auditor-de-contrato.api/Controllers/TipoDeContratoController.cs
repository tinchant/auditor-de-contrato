using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using auditor_de_contrato.domain.tipo_de_contrato_aggregation;
using auditor_de_contrato.api.infra.tipo_de_contrato_aggregation;

namespace auditor_de_contrato.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeContratoController : ControllerBase
    {
        private readonly TipoDeContratoContext _context;

        public TipoDeContratoController(TipoDeContratoContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeContrato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeContrato>>> GetTipoDeContrato()
        {
            return await _context.TipoDeContrato.ToListAsync();
        }

        // GET: api/TipoDeContrato/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeContrato>> GetTipoDeContrato(int id)
        {
            var tipoDeContrato = await _context.TipoDeContrato.FindAsync(id);

            if (tipoDeContrato == null)
            {
                return NotFound();
            }

            return tipoDeContrato;
        }

        // PUT: api/TipoDeContrato/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeContrato(int id, TipoDeContrato tipoDeContrato)
        {
            if (id != tipoDeContrato.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoDeContrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeContratoExists(id))
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

        // POST: api/TipoDeContrato
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoDeContrato>> PostTipoDeContrato(TipoDeContrato tipoDeContrato)
        {
            _context.TipoDeContrato.Add(tipoDeContrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDeContrato", new { id = tipoDeContrato.Id }, tipoDeContrato);
        }

        // DELETE: api/TipoDeContrato/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDeContrato>> DeleteTipoDeContrato(int id)
        {
            var tipoDeContrato = await _context.TipoDeContrato.FindAsync(id);
            if (tipoDeContrato == null)
            {
                return NotFound();
            }

            _context.TipoDeContrato.Remove(tipoDeContrato);
            await _context.SaveChangesAsync();

            return tipoDeContrato;
        }

        private bool TipoDeContratoExists(int id)
        {
            return _context.TipoDeContrato.Any(e => e.Id == id);
        }
    }
}
