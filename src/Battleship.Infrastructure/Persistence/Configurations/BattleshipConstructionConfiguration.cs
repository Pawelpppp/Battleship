using Microsoft.EntityFrameworkCore;

namespace Battleship.Infrastructure.Persistence.Configurations
{
    public class BattleshipConstructionConfiguration : IEntityTypeConfiguration<Domain.Entities.Battleship>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Battleship> builder)
        {
            builder.ToTable("Battleship", "BattleshipDB");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(b => b.IsDestroyed)
                .HasColumnName("isDestroyed")
                .HasDefaultValue(false);

            builder.HasMany(b => b.Area);
        }
    }
}
