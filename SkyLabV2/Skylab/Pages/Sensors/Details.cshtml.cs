using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkyLab.Models;
using Skylab.Data;

namespace Skylab.Pages.Sensors
{
    public class DetailsModel : PageModel
    {
        private readonly Skylab.Data.CellsContext _context;

        public DetailsModel(Skylab.Data.CellsContext context)
        {
            _context = context;
        }

        public Sensor Sensor { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sensor = await _context.Sensors.FirstOrDefaultAsync(m => m.ID == id);

            if (Sensor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
