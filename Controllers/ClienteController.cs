using Microsoft.AspNetCore.Mvc;


namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Cliente mcliente)
        {
            using (var _context = new HotelDbContext())
            {
                _context.Clientes.Add(mcliente);
                _context.SaveChanges();
            }
        }

        [HttpGet("TodosClientes")]
        public List<Cliente> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.Clientes.ToList();
            }
        }

        [HttpGet("Get/byID/{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.CodCliente == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("Update/byID/{id}")]
        public void Put(int id, [FromBody] Cliente mcliente)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.CodCliente == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(mcliente);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Clientes.FirstOrDefault(t => t.CodCliente == id);
                if(item == null)
                {
                    return;
                }
                _context.Clientes.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}