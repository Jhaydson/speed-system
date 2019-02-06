using SpeedSystem.Models.Enuns;

namespace SpeedSystem.Models
{
    public class Client : Person
    {
        public int ClientId { get; set; }
        public float CreditLimit { get; set; }
        public StatusClient StatusClient { get; set; }
    }
}