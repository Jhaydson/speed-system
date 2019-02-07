using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models.Maps
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Clients");

            Property(c => c.AvailableCredit)
                .HasColumnName("AvailableCredit");

            Property(c => c.StatusClient)
                .HasColumnName("StatusClient");
        }
    }
}