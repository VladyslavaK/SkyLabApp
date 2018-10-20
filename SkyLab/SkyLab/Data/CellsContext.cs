using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkyLab.Models;

namespace SkyLab.Models
{
    public class CellsContext : DbContext
    {
        public CellsContext (DbContextOptions<CellsContext> options)
            : base(options)
        {
        }

        public DbSet<SkyLab.Models.Cell> Cells { get; set; }

        public DbSet<SkyLab.Models.Sensor> Sensors { get; set; }
    }
}
