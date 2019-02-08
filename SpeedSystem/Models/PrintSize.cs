using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpeedSystem.Models
{
    public class PrintSize
    {
        [Key]
        public int PrintSizeId { get; set; }

        //Name
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("PrintSize_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        //Name
        [Required]
        [Display(Name = "Tamanho Horizontal")]
        public int SizeX { get; set; }

        //Name
        [Required]
        [Display(Name = "Tamanho Vertical")]
        public int SizeY { get; set; }


        //Valor de Custo
        [Required]
        [Display(Name = "Valor por peça minimo")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float? ValueSize { get; set; }

        [Required]
        [Display(Name = "Unidade de Medida")]
        [Range(1, int.MaxValue, ErrorMessage = "Você precisa selecionar uma opção.")]
        public int MeasureId { get; set; }

        //Relacionamentos
        public virtual Measure Measure { get; set; }


        //Data da criação do Item
        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }


    }
}