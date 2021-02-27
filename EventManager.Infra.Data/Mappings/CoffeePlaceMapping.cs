using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infra.Data.Mappings
{
    [ExcludeFromCodeCoverage]
    public class CoffeePlaceMapping : IEntityTypeConfiguration<CoffeePlace>
    {
        public void Configure(EntityTypeBuilder<CoffeePlace> builder)
        {
            builder
                .ToTable(CoffeePlaceNames.Table);

            builder
                .HasKey(h => h.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName(CoffeePlaceNames.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(p => p.Name)
                .HasColumnName(CoffeePlaceNames.Name)
                .HasMaxLength(CoffeePlace.Constraints.NameMaxLength)
                .IsRequired();
        }

        private static class CoffeePlaceNames
        {
            public const string Table = "CoffeePlaces";
            public const string Id = "Id";
            public const string Name = "Name";
        }
    }
}