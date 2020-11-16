using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Disrupt.Web.Models
{
    [Table("Tbl_Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int UsuarioId { get; set; }

        public Endereco Endereco { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required, MaxLength(14)]
        public string Cpf { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [DataType(DataType.Password), Required]
        public string Senha { get; set; }
    }
}
