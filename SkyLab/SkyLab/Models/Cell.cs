using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyLab.Models
{
    public class Cell
    {
        public long ID { get; set; }
        public string CellName { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public string Comments { get; set; }
    }
}
