using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiRest.Models.Mapping
{
    public class NORMEMap : EntityTypeConfiguration<NORME>
    {
        public NORMEMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_NORME);

            // Properties
            this.Property(t => t.ID_NORME)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DESCRIPTION)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("NORME");
            this.Property(t => t.ID_NORME).HasColumnName("ID_NORME");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
        }
    }
}
