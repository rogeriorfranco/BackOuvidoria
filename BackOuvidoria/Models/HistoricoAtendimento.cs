using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbHistoricoAtendimento")]
    public class HistoricoAtendimento
    {
        [Key]
        public long IdManifestacao { get; set; }
        public long IdCliente { get; set; }
        public string IdAnatel { get; set; }
        public DateTime DataMaxima { get; set; }
        public string Produto { get; set; }
        public string Area { get; set; }
        public string Canal { get; set; }
        public string Responsavel { get; set; }
    }
}
