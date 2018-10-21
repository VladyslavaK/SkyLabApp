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
    public class IndexModel : PageModel
    {
        private readonly Skylab.Data.CellsContext _context;

        public IndexModel(Skylab.Data.CellsContext context)
        {
            _context = context;
        }

        public IList<Sensor> Sensor { get;set; }

        public async Task OnGetAsync()
        {
            Sensor = await _context.Sensors.ToListAsync();
        }
    }
}
