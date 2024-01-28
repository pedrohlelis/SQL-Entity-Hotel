using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodConta { get; set; }
        [ForeignKey("Reserva")]
        public int FkReservaCodReserva { get; set; }

    }
}