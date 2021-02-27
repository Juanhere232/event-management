using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infra.Data.Mappings
{
    [ExcludeFromCodeCoverage]
    public class PersonCoffeePlaceAssociationMapping : IEntityTypeConfiguration<PersonCoffeePlaceAssociation>
    {
        public void Configure(EntityTypeBuilder<PersonCoffeePlaceAssociation> builder)
        {
            builder
                .ToTable(PersonCoffeePlaceAssociationNames.Table);

            builder
                .HasKey(h => new { h.PersonId, h.CoffeePlaceId });

            builder
                .Property(x => x.CoffeePlaceId)
                .HasColumnName(PersonCoffeePlaceAssociationNames.CoffeePlaceId)
                .IsRequired();

            builder
                .Property(x => x.PersonId)
                .HasColumnName(PersonCoffeePlaceAssociationNames.PersonId)
                .IsRequired();

            builder
                .HasOne(h => h.CoffeePlace)
                .WithMany(w => w.PersonCoffeePlaceAssociations)
                .HasForeignKey(h => h.CoffeePlaceId);

            builder
                .HasOne(h => h.Person)
                .WithMany(w => w.PersonCoffeePlaceAssociations)
                .HasForeignKey(h => h.PersonId);
        }

        private static class PersonCoffeePlaceAssociationNames
        {
            public const string Table = "PersonCoffeePlace";
            public const string CoffeePlaceId = "CoffeePlaceId";
            public const string PersonId = "PersonId";
        }
    }
}