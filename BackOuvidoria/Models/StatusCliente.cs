using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbStatus")]
    public class StatusCliente
    {
        [Key]
        public int Id{ get; set; }
        public long IdCliente { get; set; }
        public string DtInicio { get; set; }
        public string DtFim { get; set; }
        public string Status { get; set; }
    }
}
