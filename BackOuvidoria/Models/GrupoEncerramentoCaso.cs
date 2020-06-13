using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbGrupoEncerramentoCaso")]
    public class GrupoEncerramentoCaso
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
