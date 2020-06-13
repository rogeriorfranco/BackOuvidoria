using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbManifRegistroContato")]
    public class HistoricoContato
    {
        [JsonIgnore]
        [Key]
        public long Id { get; set; }
        public long IdManifestacao { get; set; }
        public DateTime? DataTentativa { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public string RegistradoPor { get; set; }
        public string Observacao { get; set; }
    }
}
