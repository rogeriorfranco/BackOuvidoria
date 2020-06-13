using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbResolucaoOcorrencia")]
    public class ResolucaoOcorrencia
    {
        [Key]
        public int Id { get; set; }
        public int IdOcorrencia { get; set; }
        public string Usuario { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string TipoOcorrencia { get; set; }
        public string Observacao { get; set; }
    }
}
