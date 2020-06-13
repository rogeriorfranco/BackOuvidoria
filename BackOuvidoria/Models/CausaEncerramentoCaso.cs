using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbCausaEncerramentoCaso")]
    public class CausaEncerramentoCaso
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public int idGrupoEncerramentoCaso { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
