using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Consumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodConsumo {get; set;}
        [ForeignKey("Consumivel")]
        public int FkConsumiveisCodConsumivel {get; set;}

        [ForeignKey("Conta")]
        public int FkContaCodConta {get; set;}
        public bool EntregueNoQuarto {get; set;}
        public DateTime DataHoraConsumido {get; set;}
    }
}