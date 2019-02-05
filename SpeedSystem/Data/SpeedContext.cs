using System.Data.Entity;

namespace SpeedSystem.Data
{
    public class SpeedContext : DbContext
    {
        public SpeedContext() : base ("DefaultConnection")
        {
            
        }

        public DbSet<SpeedSystem.Models.Department> Departents { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.Measure> Measures { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.ColorMesh> ColorMeshes { get; set; }
    }
}