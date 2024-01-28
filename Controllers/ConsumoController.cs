using Microsoft.AspNetCore.Mvc;


namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class ConsumoController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Consumo mConsumo)
        {
            using (var _context = new HotelDbContext())
            {
                _context.Consumo.Add(mConsumo);
                _context.SaveChanges();
            }
        }

        [HttpGet("TodosConsumos")]
        public List<Consumo> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.Consumo.ToList();
            }
        }

        [HttpGet("TodosConsumos/byContaID/{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelDbContext())
            {
                List<Consumo> items;
                items = _context.Consumo.Where(t => t.FkContaCodConta == id).ToList();
                if(items == null)
                {
                    return NotFound("Nenhum Consumo registrado nessa conta");
                }
                return new ObjectResult(items);
            }
        }

        [HttpGet("Get/byID/{id}")]
        public IActionResult GetConsumoByID(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Consumo.FirstOrDefault(t => t.CodConsumo == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("Update/byID/{id}")]
        public void Put(int id, [FromBody] Consumo mConsumo)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Consumo.FirstOrDefault(t => t.CodConsumo == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(mConsumo);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Consumo.FirstOrDefault(t => t.CodConsumo == id);
                if(item == null)
                {
                    return;
                }
                _context.Consumo.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}