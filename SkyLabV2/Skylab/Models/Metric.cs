using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyLab.Models
{
    public class Metric
    {
        public long ID { get; set; }
        public long SensorID { get; set; }
        public long MetricSystemID { get; set; }
        public long Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
