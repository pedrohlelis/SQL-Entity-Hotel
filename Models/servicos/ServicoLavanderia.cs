using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class ServicoLavanderia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodServLav {get; set;}
        public string? DescricaoServLav {get; set;}
        public decimal ValorServLav {get; set;}
    }
}