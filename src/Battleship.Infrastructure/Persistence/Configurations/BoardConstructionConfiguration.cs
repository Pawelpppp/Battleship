﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Battleship.Infrastructure.Persistence.Configurations
{
    public class BoardConstructionConfiguration : IEntityTypeConfiguration<Domain.Entities.Board>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Board> builder)
        {
            builder.ToTable("Board", "BattleshipDB");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(b => b.CreationDate)
                .HasColumnName("creationDate").HasDefaultValueSql("NOW()");

            builder.Property(b => b.LastModified)
                .HasColumnName("lastModified").HasDefaultValueSql("NOW()");

            builder.Property(b => b.IsBattleshipsDestyroyed)
                .HasColumnName("isBattleshipsDestyroyed")
                .HasDefaultValue(false);

            builder.HasMany(b => b.Battleships);
            builder.HasMany(b => b.Shots);
        }
    }
}
