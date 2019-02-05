using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedSystem.Models
{
    public class Measure
    {
        [Key]
        public int MeasureId { get; set; }

        [Required]
        [Display(Name = "Unidade de Medida")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Measure_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataCreate { get; set; }

    }
}