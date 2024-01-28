using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class ServLavPrestado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodServLavPrestado {get; set;}
        [ForeignKey("ServicoLavanderia")]
        public int FKServicosLavanderiaCodServLav {get; set;}

        [ForeignKey("Conta")]
        public int FKContaCodConta {get; set;}
    }
}