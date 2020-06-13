using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbResultadoContato")]
    public class ResultadoContato
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Id_cad { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
