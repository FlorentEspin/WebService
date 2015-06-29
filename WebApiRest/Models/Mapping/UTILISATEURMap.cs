using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiRest.Models.Mapping
{
    public class UTILISATEURMap : EntityTypeConfiguration<UTILISATEUR>
    {
        public UTILISATEURMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_UTILISATEUR);

            // Properties
            this.Property(t => t.ID_UTILISATEUR)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LOGIN)
                .IsRequired();

            this.Property(t => t.PASSWORD)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("UTILISATEUR");
            this.Property(t => t.ID_UTILISATEUR).HasColumnName("ID_UTILISATEUR");
            this.Property(t => t.LOGIN).HasColumnName("LOGIN");
            this.Property(t => t.PASSWORD).HasColumnName("PASSWORD");
        }
    }
}
