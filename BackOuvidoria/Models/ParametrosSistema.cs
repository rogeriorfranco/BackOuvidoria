using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbParametrosSistema")]
    public class ParametrosSistema
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}
