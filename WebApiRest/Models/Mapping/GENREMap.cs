using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiRest.Models.Mapping
{
    public class GENREMap : EntityTypeConfiguration<GENRE>
    {
        public GENREMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_GENRE);

            // Properties
            this.Property(t => t.ID_GENRE)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NOM_GENRE)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("GENRE");
            this.Property(t => t.ID_GENRE).HasColumnName("ID_GENRE");
            this.Property(t => t.NOM_GENRE).HasColumnName("NOM_GENRE");
        }
    }
}
