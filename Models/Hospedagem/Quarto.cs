using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Quarto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodQuarto {get; set;}
        public bool Adaptavel {get; set;}
        public short NumeroQuarto {get; set;}
        public byte CapacidadeMax {get; set;}
        [ForeignKey("TipoQuarto")]
        public int FkTiposQuartoCodTipoQuarto {get; set;}

    }
}
