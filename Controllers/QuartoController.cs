using Microsoft.AspNetCore.Mvc;


namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class QuartoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Quarto mQuarto)
        {
            using (var _context = new HotelDbContext())
            {
                _context.Quartos.Add(mQuarto);
                _context.SaveChanges();
            }
        }

        [HttpGet("TodosQuartos")]
        public List<Quarto> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.Quartos.ToList();
            }
        }

        [HttpGet("Get/byID/{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Quartos.FirstOrDefault(t => t.CodQuarto == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("Update/byID/{id}")]
        public void Put(int id, [FromBody] Quarto mQuarto)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Quartos.FirstOrDefault(t => t.CodQuarto == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(mQuarto);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Quartos.FirstOrDefault(t => t.CodQuarto == id);
                if(item == null)
                {
                    return;
                }
                _context.Quartos.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}