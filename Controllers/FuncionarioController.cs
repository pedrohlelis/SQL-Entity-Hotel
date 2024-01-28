using Microsoft.AspNetCore.Mvc;

namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        [HttpPost]
        public void Post([FromBody] Funcionario mFuncionario)
        {
            using (var _context = new HotelDbContext())
            {
                _context.Funcionarios.Add(mFuncionario);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<Funcionario> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.Funcionarios.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.CodFuncionario == id);
                if(item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Funcionario mFuncionario)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.CodFuncionario == id);
                if(item == null)
                {
                    return;
                }
                _context.Entry(item).CurrentValues.SetValues(mFuncionario);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Funcionarios.FirstOrDefault(t => t.CodFuncionario == id);
                if(item == null)
                {
                    return;
                }
                _context.Funcionarios.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}