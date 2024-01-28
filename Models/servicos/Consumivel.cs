using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Consumivel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodConsumivel {get; set;}
        public string? DescricaoConsumivel {get; set;}
        public decimal ValorConsumivel {get; set;}

    }
}