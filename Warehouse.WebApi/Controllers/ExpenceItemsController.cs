using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pckt.Shared;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceItemsController : ControllerBase
    {
        private readonly WarehouseContext _context;

        public ExpenceItemsController(WarehouseContext context)
        {
            _context = context;
        }

        // GET: api/ExpenceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenceItem>>> GetExpenceItems()
        {
          if (_context.ExpenceItems == null)
          {
              return NotFound();
          }
            return await _context.ExpenceItems.ToListAsync();
        }

        // GET: api/ExpenceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenceItem>> GetExpenceItem(long id)
        {
          if (_context.ExpenceItems == null)
          {
              return NotFound();
          }
            var expenceItem = await _context.ExpenceItems.FindAsync(id);

            if (expenceItem == null)
            {
                return NotFound();
            }

            return expenceItem;
        }

        // PUT: api/ExpenceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenceItem(long id, ExpenceItem expenceItem)
        {
            if (id != expenceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenceItemExists(id))
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

        // POST: api/ExpenceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExpenceItem>> PostExpenceItem(ExpenceItem expenceItem)
        {
          if (_context.ExpenceItems == null)
          {
              return Problem("Entity set 'WarehouseContext.ExpenceItems'  is null.");
          }
            _context.ExpenceItems.Add(expenceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenceItem", new { id = expenceItem.Id }, expenceItem);
        }

        // DELETE: api/ExpenceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenceItem(long id)
        {
            if (_context.ExpenceItems == null)
            {
                return NotFound();
            }
            var expenceItem = await _context.ExpenceItems.FindAsync(id);
            if (expenceItem == null)
            {
                return NotFound();
            }

            _context.ExpenceItems.Remove(expenceItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenceItemExists(long id)
        {
            return (_context.ExpenceItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
