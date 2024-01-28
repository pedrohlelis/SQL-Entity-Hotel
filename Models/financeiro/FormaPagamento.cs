using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class FormaPagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodFormaPag {get; set;}
        [StringLength(30)]
        public string? FormaDePagamento {get; set;}
    }
}