using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ouvidoria.Models
{
    [Table("TbDadosCliente")]
    public class DadosCliente
    {
        [Key]
        public long IdCliente { get; set; }
        public string StatusNet { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string NetFone { get; set; }
        public string Segmento { get; set; }
        public long IdAssinante { get; set; }
        public string TipoContrato { get; set; }
        public string TipoCliente { get; set; }
        public string CodigoNet { get; set; }
        public string StatusEmbratel { get; set; }
        public string CodigoEmbratel { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        public string Cep { get; set; }
        public string protocolo { get; set; }
    }
}
