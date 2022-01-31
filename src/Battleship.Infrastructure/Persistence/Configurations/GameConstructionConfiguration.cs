using Battleship.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Battleship.Infrastructure.Persistence.Configurations
{
    public class GameConstructionConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game", "BattleshipDB");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.CreationDate)
                .HasColumnName("creationDate").HasDefaultValueSql("NOW()");

            builder.Property(b => b.LastModified)
                .HasColumnName("lastModified").HasDefaultValueSql("NOW()");

            builder.Property(b => b.IsBoardAMove)
                .HasColumnName("isBoardAMove");

            // relations
            builder.HasMany(b => b.Boards).WithOne(b => b.GameOwner).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
