using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Cargo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCargo {get; set;}
        [StringLength(25)]
        public string? NomeCargo {get; set;}
    }
}

