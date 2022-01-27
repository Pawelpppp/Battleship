using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Infrastructure.Persistence.Configurations
{
    internal class BattleshipConstructionConfiguration : IEntityTypeConfiguration<Domain.Entities.Battleship>
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
        }
    }
}
