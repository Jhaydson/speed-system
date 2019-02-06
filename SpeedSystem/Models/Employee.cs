using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedSystem.Models
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public float Commission { get; set; }
        public int DepartmentId { get; set; }

        public Department Departments { get; set; }
    }
}