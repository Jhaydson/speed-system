using System.Data.Entity;

namespace SpeedSystem.Data
{
    public class SpeedContext : DbContext
    {
        public SpeedContext() : base("DefaultConnection")
        {

        }

        public DbSet<SpeedSystem.Models.Department> Departents { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.Measure> Measures { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.ColorMesh> ColorMeshes { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.Mesh> Meshes { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.PrintSize> PrintSizes { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.TechnicalPrint> TechnicalPrints { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.Client> Clients { get; set; }
    }
}