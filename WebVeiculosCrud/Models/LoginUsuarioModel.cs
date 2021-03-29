using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebVeiculosCrud.Models
{

    [Table("LoginUsuario")]
    public class LoginUsuarioModel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Detalhes")]
        [Display(Name = "Detalhes")]
        public string Detalhes { get; set; }

        [Column("EmailUsuario")]
        [Display(Name = "Email Usuário")]
        public string EmailUsuario { get; set; }
    }
}
