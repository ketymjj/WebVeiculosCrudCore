using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebVeiculosCrud.Models
{

    [Table ("Veiculos")]
    public class VeiculosModel
    {
        [Column ("Id")]
        [Display (Name = "Código")]
        public int Id { get; set; }

        [Column("Marca")]
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "A marca é obrigatório", AllowEmptyStrings = false)]
        public string Marca { get; set; }

        [Column("Modelo")]
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "O modelo é obrigatório", AllowEmptyStrings = false)]
        public string Modelo { get; set; }

        [Column("Versao")]
        [Display(Name = "Versao")]
        [Required(ErrorMessage = "A versão é obrigatório", AllowEmptyStrings = false)]
        public string Versao { get; set; }

        [Column("Ano")]
        [Display(Name = "Ano")]
        [Required(ErrorMessage = "O ano é obrigatório", AllowEmptyStrings = false)]
        public int Ano { get; set; }

        [Column("Quilometragem")]
        [Display(Name = "Quilometragem")]
        [Required(ErrorMessage = "A quilometragem é obrigatório", AllowEmptyStrings = false)]
        public int Quilometragem { get; set; }

        [Column("Observacao")]
        [Display(Name = "Observacao")]
        [Required(ErrorMessage = "A obsercação é obrigatório", AllowEmptyStrings = false)]
        public string Observacao { get; set; }
    }
}
