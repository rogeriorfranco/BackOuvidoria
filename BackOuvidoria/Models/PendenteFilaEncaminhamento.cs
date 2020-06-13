using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbPendenteFilaEncaminhamento")]
    public class PendenteFilaEncaminhamento
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int IdCad { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
