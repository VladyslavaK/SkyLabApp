﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Skylab.Data.CellsContext _context;

        public DetailsModel(Skylab.Data.CellsContext context)
        {
            _context = context;
        }

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
    }
}
