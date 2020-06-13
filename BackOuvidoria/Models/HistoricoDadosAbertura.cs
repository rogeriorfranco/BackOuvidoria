using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbManifDadosManifestacao")]
    public class HistoricoDadosAbertura
    {
        [Key]
        public long Id { get; set; }
        public long IdManifestacao { get; set; }
        public string Motivo { get; set; }
        public string SubMotivo { get; set; }
        public string Protocolo { get; set; }
        public string Descricao { get; set; }

    }
}
