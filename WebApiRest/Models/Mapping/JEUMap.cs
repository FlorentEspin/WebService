using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiRest.Models.Mapping
{
    public class JEUMap : EntityTypeConfiguration<JEU>
    {
        public JEUMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_JEU);

            // Properties
            this.Property(t => t.ID_JEU)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NOM_JEU)
                .IsRequired();

            this.Property(t => t.DESCRIPTIF)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("JEU");
            this.Property(t => t.ID_JEU).HasColumnName("ID_JEU");
            this.Property(t => t.ID_NORME).HasColumnName("ID_NORME");
            this.Property(t => t.NOM_JEU).HasColumnName("NOM_JEU");
            this.Property(t => t.DATE_DE_SORTIE).HasColumnName("DATE_DE_SORTIE");
            this.Property(t => t.DESCRIPTIF).HasColumnName("DESCRIPTIF");
            this.Property(t => t.IMAGE).HasColumnName("IMAGE");

            // Relationships
            this.HasMany(t => t.GENREs)
                .WithMany(t => t.JEUs)
                .Map(m =>
                    {
                        m.ToTable("CLASSE");
                        m.MapLeftKey("ID_JEU");
                        m.MapRightKey("ID_GENRE");
                    });

            this.HasMany(t => t.EDITEURs)
                .WithMany(t => t.JEUs)
                .Map(m =>
                    {
                        m.ToTable("EDITE");
                        m.MapLeftKey("ID_JEU");
                        m.MapRightKey("ID_EDITEUR");
                    });

            this.HasRequired(t => t.NORME)
                .WithMany(t => t.JEUs)
                .HasForeignKey(d => d.ID_NORME);

        }
    }
}
