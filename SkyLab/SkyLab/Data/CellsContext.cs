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

        public DbSet<Cell> Cells { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<CellSensors> CellSensors { get; set; }

        public DbSet<MetricSystem> MetricSystem { get; set; }

        public DbSet<Metric> Metrics { get; set; }
    }
}
