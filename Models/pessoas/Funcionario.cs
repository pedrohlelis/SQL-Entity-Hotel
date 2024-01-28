using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodFuncionario {get; set;}
        [StringLength(100)]
        public string? NomeFuncionario {get; set;}
        [ForeignKey("Cargo")]
        public int FkCargoCodCargo {get; set;}
        public Cargo? Cargo {get; set;}
    }
}