using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiRest.Models.Mapping
{
    public class EDITEURMap : EntityTypeConfiguration<EDITEUR>
    {
        public EDITEURMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_EDITEUR);

            // Properties
            this.Property(t => t.ID_EDITEUR)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NOM_EDITEUR)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EDITEUR");
            this.Property(t => t.ID_EDITEUR).HasColumnName("ID_EDITEUR");
            this.Property(t => t.NOM_EDITEUR).HasColumnName("NOM_EDITEUR");
        }
    }
}
