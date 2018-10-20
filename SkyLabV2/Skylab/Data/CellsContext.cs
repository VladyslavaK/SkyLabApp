using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyLab.Models;

namespace Skylab.Data
{ 
    public class CellsContext : IdentityDbContext
    {
        public CellsContext(DbContextOptions<CellsContext> options)
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
