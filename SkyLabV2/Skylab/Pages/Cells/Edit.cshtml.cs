using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyLab.Models;
using Skylab.Data;

namespace Skylab.Pages.Cells
{
    public class EditModel : PageModel
    {
        private readonly Skylab.Data.CellsContext _context;

        public EditModel(Skylab.Data.CellsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cell Cell { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cell = await _context.Cells.FirstOrDefaultAsync(m => m.ID == id);

            if (Cell == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellExists(Cell.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CellExists(long id)
        {
            return _context.Cells.Any(e => e.ID == id);
        }
    }
}
