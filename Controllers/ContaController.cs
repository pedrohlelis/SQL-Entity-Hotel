using Microsoft.AspNetCore.Mvc;


namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Conta mConta)
        {
            using (var _context = new HotelDbContext())
            {
                _context.Conta.Add(mConta);
                _context.SaveChanges();
            }
        }

        [HttpGet("TodosContas")]
        public List<Conta> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.Conta.ToList();
            }
        }

        [HttpGet("Get/byID/{id}")]
        public IActionResult GetContaByID(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Conta.FirstOrDefault(t => t.CodConta == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("Update/byID/{id}")]
        public void Put(int id, [FromBody] Conta mConta)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Conta.FirstOrDefault(t => t.CodConta == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(mConta);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Conta.FirstOrDefault(t => t.CodConta == id);
                if(item == null)
                {
                    return;
                }
                _context.Conta.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}