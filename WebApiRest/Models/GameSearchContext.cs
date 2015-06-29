using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebApiRest.Models.Mapping;

namespace WebApiRest.Models
{
    public partial class GameSearchContext : DbContext
    {
        static GameSearchContext()
        {
            Database.SetInitializer<GameSearchContext>(null);
        }

        public GameSearchContext()
            : base("Name=GameSearchContext")
        {
        }

        public DbSet<EDITEUR> EDITEURs { get; set; }
        public DbSet<GENRE> GENREs { get; set; }
        public DbSet<JEU> JEUs { get; set; }
        public DbSet<NORME> NORMEs { get; set; }
        public DbSet<UTILISATEUR> UTILISATEURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EDITEURMap());
            modelBuilder.Configurations.Add(new GENREMap());
            modelBuilder.Configurations.Add(new JEUMap());
            modelBuilder.Configurations.Add(new NORMEMap());
            modelBuilder.Configurations.Add(new UTILISATEURMap());
        }
    }
}
