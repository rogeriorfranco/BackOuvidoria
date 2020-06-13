using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbFatura")]
    public class Fatura
    {
        [Key]
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataVencimento { get; set; } 
        public string Parceiro { get; set; }
        public string ModalidadeCobranca { get; set; }
        public string Situacao { get; set; }
		public DateTime DataPagamento { get; set; } 
        public Decimal Valor { get; set; }
        public string RetDoc { get; set; }
        public bool FlagContestado { get; set; }
		public bool FlagFatPago { get; set; }
		public bool FlagIntencPagamento { get; set; }
    }
}
