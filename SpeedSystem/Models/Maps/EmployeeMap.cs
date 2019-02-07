using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models.Maps
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employees");

            Property(c => c.Commission)
                .HasColumnName("Commission");

            Property(c => c.DepartmentId)
                .HasColumnName("DepartmentId");
        }
    }
}