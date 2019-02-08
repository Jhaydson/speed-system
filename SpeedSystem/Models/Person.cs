using SpeedSystem.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI;

namespace SpeedSystem.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        //Name
        [Required]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        public string PhysicalOrLegalName { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "O Campo {0} recebe no máximo 100 caracteres")]
        public string LastNameOrFantasyName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Foto de Perfil")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Display(Name = "Sexo")]
        public Genre Gnere { get; set; }

        [Required]
        [Display(Name = "Tipo de Pessoa")]
        [Themeable(false)]
        public TypePerson TypePerson { get; set; }

        [Required]
        public string CpfOrCnpj { get; set; }

        
        public string RGOrStateRegistration { get; set; }

        [Required]
        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DateBirthOrOpening { get; set; }

                
        [MaxLength(100, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        public string Responsible { get; set; }


        public virtual List<Telephone> Telephones { get; set; }
        public virtual List<Address> Address { get; set; }

        
        //Data da criação do Item
        [Column(TypeName = "DateTime2")]
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public DateTime DataCreate { get; set; }

    }
}