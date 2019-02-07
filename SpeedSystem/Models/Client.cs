using SpeedSystem.Models.Enuns;
using System.ComponentModel.DataAnnotations;

namespace SpeedSystem.Models
{
    public class Client : Person
    {
        [Display(Name = "Crédito disponivel")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float AvailableCredit { get; set; }

        [Display(Name = "Estado do Cliente")]
        public StatusClient StatusClient { get; set; }
    }
}