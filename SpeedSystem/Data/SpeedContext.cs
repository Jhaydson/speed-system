using System.Data.Entity;

namespace SpeedSystem.Data
{
    public class SpeedContext : DbContext
    {
        public SpeedContext() : base ("DefaultConnection")
        {
            
        }

        public DbSet<SpeedSystem.Models.Department> Departents { get; set; }

       
    }
}