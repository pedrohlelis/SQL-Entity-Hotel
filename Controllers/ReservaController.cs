using Microsoft.AspNetCore.Mvc;


namespace HotelCodeFirst
{
    [Route("Hotel/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Reserva mreserva)
        {
            using (var _context = new HotelDbContext())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Reservas.Add(mreserva);
                        _context.SaveChanges();

                        Conta conta = new Conta
                        {
                            FkReservaCodReserva = mreserva.CodReserva
                        };

                        _context.Conta.Add(conta);
                        _context.SaveChanges();

                        transaction.Commit();

                        return Ok("Reserva Registrada com sucesso!");
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        return BadRequest("Parece que algo deu errado... Tente novamente. " + e.Message);
                    }
                }
            }
        }

        [HttpGet("TodasReservas")]
        public List<Reserva> Get()
        {
            using (var _context = new HotelDbContext())
            {
                return _context.Reservas.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.CodReserva == id);
                if(item == null)
                {
                    return NotFound("Ops! Nenhuma reserva encontrada.");
                }
                return new ObjectResult(item);
            }
        }

        [HttpPut("Update/byID/{id}")]
        public IActionResult Put(int id, [FromBody] Reserva mreserva)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.CodReserva == id);
                if(item == null)
                {
                    return NotFound("Ops! Nenhuma reserva encontrada.");
                }
                _context.Entry(item).CurrentValues.SetValues(mreserva);
                _context.SaveChanges();
                return Ok("A reserva foi atualizada com sucesso!");
            }
        }

        [HttpPut("Cancelar/byID/{id}")]
        public IActionResult Put(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.CodReserva == id);
                if(item == null)
                {
                    return NotFound("Ops! Nenhuma reserva com esse ID encontrada.");
                }
                item.Cancelada = true;
                _context.Reservas.Update(item);
                _context.SaveChanges();
                return Ok("A reserva foi cancelada com sucesso!");
            }
        }

        [HttpDelete("Delete/byID/{id}")]
        public IActionResult Delete(int id)
        {
            using (var _context = new HotelDbContext())
            {
                var item = _context.Reservas.FirstOrDefault(t => t.CodReserva == id);
                if(item == null)
                {
                    return NotFound("Ops! Nenhuma reserva encontrada.");;
                }
                _context.Reservas.Remove(item);
                _context.SaveChanges();
                return Ok("A reserva foi removida com sucesso.");
            }
        }
    }
}