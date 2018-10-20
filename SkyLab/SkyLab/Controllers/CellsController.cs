using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyLab.Models;

namespace SkyLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellsController : ControllerBase
    {
        private readonly CellsContext _context;

        public CellsController(CellsContext context)
        {
            _context = context;
        }

        // GET: api/Cells
        [HttpGet]
        public IEnumerable<Cell> GetCell()
        {
            return _context.Cells;
        }

        // GET: api/Cells/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCell([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cell =  await _context.Cells.FindAsync(id);
            var sensors = from a in _context.CellSensors 
                            join d in _context.Sensors on a.SensorID equals d.ID
                            where a.CellID == id
                            select d;

            if (cell == null)
            {
                return NotFound();
            }

            return Ok(new { Cell = cell, Sensors = sensors});
        }

        // PUT: api/Cells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCell([FromRoute] long id, [FromBody] Cell cell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cell.ID)
            {
                return BadRequest();
            }

            _context.Entry(cell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellExists(id))
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

        // POST: api/Cells
        [HttpPost]
        public async Task<IActionResult> PostCell([FromBody] Cell cell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cells.Add(cell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCell", new { id = cell.ID }, cell);
        }

        // DELETE: api/Cells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCell([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cell = await _context.Cells.FindAsync(id);
            if (cell == null)
            {
                return NotFound();
            }

            _context.Cells.Remove(cell);
            await _context.SaveChangesAsync();

            return Ok(cell);
        }

        private bool CellExists(long id)
        {
            return _context.Cells.Any(e => e.ID == id);
        }
    }
}