using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbQuandoUsarEncerramentoCaso")]
    public class QuandoUsarEncerramentoCaso
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public int idCausaEncerramentoCaso { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
