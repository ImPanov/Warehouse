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
    public class ReceiptItemsController : ControllerBase
    {
        private readonly WarehouseContext _context;

        public ReceiptItemsController(WarehouseContext context)
        {
            _context = context;
        }

        // GET: api/ReceiptItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptItem>>> GetReceiptItems()
        {
          if (_context.ReceiptItems == null)
          {
              return NotFound();
          }
            return await _context.ReceiptItems.ToListAsync();
        }

        // GET: api/ReceiptItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptItem>> GetReceiptItem(long id)
        {
          if (_context.ReceiptItems == null)
          {
              return NotFound();
          }
            var receiptItem = await _context.ReceiptItems.FindAsync(id);

            if (receiptItem == null)
            {
                return NotFound();
            }

            return receiptItem;
        }

        // PUT: api/ReceiptItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiptItem(long id, ReceiptItem receiptItem)
        {
            if (id != receiptItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(receiptItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptItemExists(id))
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

        // POST: api/ReceiptItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReceiptItem>> PostReceiptItem(ReceiptItem receiptItem)
        {
          if (_context.ReceiptItems == null)
          {
              return Problem("Entity set 'WarehouseContext.ReceiptItems'  is null.");
          }
            _context.ReceiptItems.Add(receiptItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceiptItem", new { id = receiptItem.Id }, receiptItem);
        }

        // DELETE: api/ReceiptItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiptItem(long id)
        {
            if (_context.ReceiptItems == null)
            {
                return NotFound();
            }
            var receiptItem = await _context.ReceiptItems.FindAsync(id);
            if (receiptItem == null)
            {
                return NotFound();
            }

            _context.ReceiptItems.Remove(receiptItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiptItemExists(long id)
        {
            return (_context.ReceiptItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
