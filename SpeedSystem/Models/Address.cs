using SpeedSystem.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        //Numero
        [Required]
        [Display(Name = "Logradouro")]
        public string PublicPlace { get; set; }

        //Quadra
        [Required]
        [Display(Name = "Quadra")]
        public string Block { get; set; }

        //Lote
        [Required]
        [Display(Name = "Lote")]
        public string Lot { get; set; }

        //CEP
        [Required]
        [Display(Name = "CEP")]
        public string ZipCode { get; set; }

        //Numero
        [Required]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        //Numero
        [Required]
        [Display(Name = "Estado")]
        public string State { get; set; }

        //Numero
        [Required]
        [Display(Name = "Tipo de Endereço")]
        public TypeAddress TypeAddress { get; set; }


        //Relacionamento
        public int PersonId { get; set; }
        public ICollection<Person> Persons { get; set; }

    }
}