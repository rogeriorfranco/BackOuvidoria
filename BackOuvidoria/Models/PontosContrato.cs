using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbPontosContrato")]
    public class PontosContrato
    {
        [Key]
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public string PontoContrato { get; set; }
        public string Inst { get; set; }
        public string Endereco { get; set; }
        public string NumeroSerie { get; set; }
        public string Tipo { get; set; }
    }
}
