using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbProdutoPonto")]
    public class ProdutoPonto
    {
        [Key]
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public string Produto { get; set; }
        public string Inst { get; set; }
    }
}
