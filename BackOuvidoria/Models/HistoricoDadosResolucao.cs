using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbHistoricoDadosResolucao")]
    public class HistoricoDadosResolucao
    {
        [Key]
        public int IdManifestacao { get; set; }
        public DateTime DataResolucao { get; set; }
        public DateTime DataSla { get; set; }
        public string Login { get; set; }
        public string Protocolo { get; set; }
        public string CausaProblema { get; set; }
        public string Ofensor { get; set; }
        public string Solucao { get; set; }
    }
}
