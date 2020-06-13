using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbSolucaoEncerramentoCaso")]
    public class SolucaoEncerramentoCaso
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public int IdCausaEncerramentoCaso { get; set; }
        [JsonIgnore]
        public bool Status { get; set; }
    }
}
