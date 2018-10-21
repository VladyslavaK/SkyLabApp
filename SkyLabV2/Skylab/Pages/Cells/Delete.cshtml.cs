using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkyLab.Models;
using Skylab.Data;

namespace Skylab.Pages.Cells
{
    public class DeleteModel : PageModel
    {
        private readonly Skylab.Data.CellsContext _context;

        public DeleteModel(Skylab.Data.CellsContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cell = await _context.Cells.FindAsync(id);

            if (Cell != null)
            {
                _context.Cells.Remove(Cell);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
