using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models
{
    public class TechnicalPrint
    {
        [Key]
        public int TechnicalPrintId { get; set; }

        //Name
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("TechnicalPrint_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        //Valor de Custo
        [Required]
        [Display(Name = "Valor Por Tela")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float? CustValue { get; set; }


    }
}