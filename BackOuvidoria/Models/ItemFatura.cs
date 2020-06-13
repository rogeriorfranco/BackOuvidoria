using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbItemFatura")]
    public class ItemFatura
    {
        [Key]
        public int Id { get; set; }
        public int IdFatura { get; set; }
        public bool? FlagContestado { get; set; }
        public string Item { get; set; }
        public Decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Motivo { get; set; }
        public string TipoValor { get; set; }
        public Decimal ValorContratado { get; set; }
        public Decimal? Saldo { get; set; }
        public string Observacao { get; set; }
    }
}
