using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;
namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext ctx)
        {
            _context = ctx;

        }
        [HttpGet("{id:int}",Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.Find(id);

            if (celestialObject == null)
                return NotFound();
            celestialObject.Satellites = _context.CelestialObjects.Where(c => c.OrbitedObjectId == id).ToList();
            return Ok(celestialObject);


        }
        [HttpGet("{name}")]
        public IActionResult GetbyName(string name)
        {
            var co = _context.CelestialObjects.Where(e => e.Name == name).ToList();

           if(!co.Any())
                return NotFound();
          foreach(var c in co)
            {
                c.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == c.Id).ToList();
            }
            return Ok(co);
        }

        [HttpGet("")]
        public IActionResult GetAll ()
        {
            var co = _context.CelestialObjects.ToList();
            return Ok(co);


        }
    }
}
