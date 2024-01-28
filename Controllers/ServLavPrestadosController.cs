using Microsoft.AspNetCore.Mvc;


namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class ServLavPrestadoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] ServLavPrestado mServLavPrestado)
        {
            using (var _context = new HotelDbContext())
            {
                _context.ServLavPrestados.Add(mServLavPrestado);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<ServLavPrestado> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.ServLavPrestados.ToList();
            }
        }

        [HttpGet("TodosServLavPrestados/byContaID/{id}")]
        public IActionResult GetServicosByID(int id)
        {
            using (var _context = new HotelDbContext())
            {
                List<ServLavPrestado> items;
                items = _context.ServLavPrestados.Where(t => t.FKContaCodConta == id).ToList();
                if(items == null)
                {
                    return NotFound("Nenhum Servico da Lavanderia registrado nessa conta");
                }
                return new ObjectResult(items);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.ServLavPrestados.FirstOrDefault(t => t.CodServLavPrestado == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("Update/byID/{id}")]
        public void Put(int id, [FromBody] ServLavPrestado mServLavPrestado)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.ServLavPrestados.FirstOrDefault(t => t.CodServLavPrestado == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(mServLavPrestado);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.ServLavPrestados.FirstOrDefault(t => t.CodServLavPrestado == id);
                if(item == null)
                {
                    return;
                }
                _context.ServLavPrestados.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}