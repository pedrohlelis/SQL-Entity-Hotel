using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class TipoQuarto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodTipoQuarto { get; set; }
        [StringLength(15)]
        public string? TipoDoQuarto { get; set; }
    }
}