using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models.ViewModels
{
    public class ClientViewModel
    {
        public Client Clients { get; set; }
        public Telephone Telephones { get; set; }
        public Address Address { get; set; }
    }
}