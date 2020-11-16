using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Disrupt.Web.Models
{
    [Table("Tbl_Endereco")]
    public class Endereco
    {
        [Column("Id")]
        public int EnderecoId { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cidade{ get; set; }
        [Required]
        public string Cep { get; set; }
    }
}
