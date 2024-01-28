using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelCodeFirst
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCliente {get; set;}
        [StringLength(100)]
        public string? NomeCliente {get; set;}
        [StringLength(150)]
        public string? EnderecoCliente {get; set;}
        [StringLength(50)]
        public string? Nacionalidade {get; set;}
        [StringLength(100)]
        public string? Email {get; set;}
        [StringLength(13)]
        public string? Telefone {get; set;}
    }
}