using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        public System.Data.Entity.DbSet<SpeedSystem.Models.Client> People { get; set; }

        public System.Data.Entity.DbSet<SpeedSystem.Models.Telephone> Telephones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Models.Maps.ClientMap());
            modelBuilder.Configurations.Add(new Models.Maps.PersonMap());
            modelBuilder.Configurations.Add(new Models.Maps.EmployeeMap());

            // DESABILITAR CASCATAS
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        
        
    }
}