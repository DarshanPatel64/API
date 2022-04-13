using KeyValueAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeyValueAPI.Controllers
{
    public class DataController : ControllerBase
    {
        private ApiDataDbContext _context;


        [Route("keys/[Controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            _context = new ApiDataDbContext();
            var data = _context.data;
            return Ok(data);
        }
        [HttpGet("keys/{key}")]
        public IActionResult Get(string key)
        {
            _context = new ApiDataDbContext();
            var data = _context.data.Where(k => k.Key == key);
            return (data == null) ? NotFound() : Ok(data);
        }

        [HttpPost("keys")]
        
        public IActionResult Post([FromBody]data d)
        {
            _context = new ApiDataDbContext();
            var data = _context.data.FirstOrDefault(k => k.Key == d.Key);
            if (data == null)
            {
                _context.data.Add(d);
                _context.SaveChanges();
                return Created("keys", d);
                
            }
            else
            {
                return Conflict("Key Already exists!");
            }
        }

        [HttpPatch("keys/{key}/{value}")]

        public IActionResult Patch(string key, string value)
        {
            _context = new ApiDataDbContext();
            var data = _context.data.FirstOrDefault(k => k.Key == key);
            if (data == null) return NotFound();
            else
            {
                data.Value = value;
                _context.SaveChanges();
                return Ok(data);
            }
        }

        [HttpDelete("keys/{key}")]
        public IActionResult Delete(string key)
        {
            _context = new ApiDataDbContext();
            var data = _context.data.FirstOrDefault(k => k.Key == key);
            if (data == null) return NotFound();
            else
            {
                _context.data.Remove(data);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
