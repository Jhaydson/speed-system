using SpeedSystem.Models.Enuns;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace SpeedSystem.Models
{
    public class Mesh
    {
        [Key]
        public int MeshId { get; set; }

        //Name
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        [Index("Mesh_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        //Valor de Custo
        [Required]
        [Display(Name = "Valor de Custo")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float? CustValue { get; set; }

       
        //Se a malha aceita a tecnica chamada sublimação
        [Required]
        [Display(Name = "Aceita Sublimação")]
        public YesOrNo Sublimation { get; set; }

        [Required]
        [Display(Name = "Unidade de Medida")]
        [Range(1, int.MaxValue, ErrorMessage = "Você precisa selecionar uma opção.")]
        public int MeasureId { get; set; }


        [Required]
        [Display(Name = "Cor da Malha")]
        [Range(1, int.MaxValue, ErrorMessage = "Você precisa selecionar uma opção.")]
        public int ColorMeshId { get; set; }
        

        //Relacionamentos
        public virtual Measure Measure { get; set; }
        public virtual ColorMesh ColorMesh { get; set; }


        //Data da criação do Item
        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }
    }
}