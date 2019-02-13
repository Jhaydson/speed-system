using SpeedSystem.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models
{
    public class Telephone
    {
        [Key]
        public int TelephoneId { get; set; }

        //Numero
        [Required]
        [Display(Name = "Numero")]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }

        //Tipo de Telefone
      
        [Display(Name = "Tipo de Telefone")]
        public TypeTelephone TypeTelephone { get; set; }

        //Se é Whatsapp
        
        [Display(Name = "Whatsapp?")]
        public YesOrNo YesOrNo { get; set; }

        //Relacionamento
        public int PersonId { get; set; }
        public virtual ICollection<Person> Person { get; set; }

    }
}