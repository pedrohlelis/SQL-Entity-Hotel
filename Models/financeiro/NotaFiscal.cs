using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelCodeFirst
{
    public class NotaFiscal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodNotaFiscal { get; set;}
        public decimal ValorTotal {get; set;}
        public DateTime DataEmissao {get; set;}
        [ForeignKey("Conta")]
        public int FkContaCodConta { get; set;}
        [ForeignKey("FormaPagamento")]
        public int FkFormasPagamentoCodFormaPag { get; set;}
    }
}