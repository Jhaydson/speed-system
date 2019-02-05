using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedSystem.Models
{
    public class ColorMesh
    {
        [Key]
        public int ColorMeshId { get; set; }

        [Required]
        [Display(Name = "Cor")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("ColorMesh_Name_Index", IsUnique = true)]
        public string Color { get; set; }

        
        public virtual ICollection<Mesh> Mesh { get; set; }



        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }
    }
}