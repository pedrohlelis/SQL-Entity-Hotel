using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Filial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodFilial {get; set;}
        [StringLength(100)]
        public string? NomeFilial {get; set;}
        [StringLength(150)]
        public string? EnderecoFilial {get; set;}
        public short NumeroDeQuartos {get; set;}
        public byte Estrelas {get; set;}
    }
}