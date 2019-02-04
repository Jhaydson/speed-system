using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models
{
    public class Teste
    {
        public int TesteId { get; set; }
        [Required]
        [Display(Name = "Departamentos")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Department_Name_Index", IsUnique = true)]
        public string Name { get; set; }
    }
}