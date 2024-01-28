using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodReserva { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Cancelada { get; set; }
        public bool ColchaoAdicional { get; set; }

        [ForeignKey("Cliente")]
        public int FkClientesCodCliente { get; set; }

        [ForeignKey("Quarto")]
        public int FkQuartosCodQuarto { get; set; }

        [ForeignKey("Funcionario")]
        public int FkFuncionariosCodFuncionario { get; set; }

    }
}