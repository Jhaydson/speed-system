using SpeedSystem.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpeedSystem.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        //Name
        [Required]
        [Display(Name = "Primeiro Nome")]
        [MaxLength(50, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Sobrenome")]
        [MaxLength(100, ErrorMessage = "O Campo {0} recebe no máximo 50 caracteres")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Foto de Perfil")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        public Genre Gnere { get; set; }

        public TypePerson TypePerson { get; set; }

        [Required]
        [Display(Name = "Cpf ou Cnpj")]
        public string CpfOrCnpj { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento ou Abertura")]
        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }

        public virtual List<Telephone> Telephones { get; set; }
        public virtual List<Address> Address { get; set; }
    }
}