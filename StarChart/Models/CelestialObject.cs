using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarChart.Models
{
    public class CelestialObject
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        int? OrbitedObjectId { get; set; }
        [NotMapped]
        public List<CelestialObject> Sattellite { get; set; }
        public TimeSpan OrbitalPeriod { get; set; }
    }
}
