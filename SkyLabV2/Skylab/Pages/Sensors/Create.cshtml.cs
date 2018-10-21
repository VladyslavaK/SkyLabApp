using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyLab.Models;
using Skylab.Data;

namespace Skylab.Pages.Sensors
{
    public class CreateModel : PageModel
    {
        private readonly Skylab.Data.CellsContext _context;

        public CreateModel(Skylab.Data.CellsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sensor Sensor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sensors.Add(Sensor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}