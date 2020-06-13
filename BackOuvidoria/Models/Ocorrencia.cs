using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Models
{
    [Table("TbOcorrencias")]
    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }
        public long IdCliente { get; set; }
        public string Numero { get; set; }
        public DateTime? DtAbertura { get; set; }
        public DateTime? DtFechamento { get; set; }
        public string Cod { get; set; }
        public string Observacao { get; set; }
        public string Usuario { get; set; }
        public string Origem { get; set; }
        public string GrupoOcorrencia { get; set; }
        public string TipoOcorrencia { get; set; }
        public bool FlagResolvido { get; set; }
        public string Contato { get; set; }
        public string Fone { get; set; }
    }
}
