using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infra.Data.Mappings
{
    [ExcludeFromCodeCoverage]
    public class PersonEventRoomAssociationMapping : IEntityTypeConfiguration<PersonEventRoomAssociation>
    {
        public void Configure(EntityTypeBuilder<PersonEventRoomAssociation> builder)
        {
            builder
                .ToTable(PersonEventRoomAssociationNames.Table);

            builder
                .HasKey(h => new { h.PersonId, h.EventRoomId });

            builder
                .Property(x => x.EventRoomId)
                .HasColumnName(PersonEventRoomAssociationNames.EventRoomId)
                .IsRequired();

            builder
                .Property(x => x.PersonId)
                .HasColumnName(PersonEventRoomAssociationNames.PersonId)
                .IsRequired();

            builder
                .HasOne(h => h.EventRoom)
                .WithMany(w => w.PersonEventRoomAssociations)
                .HasForeignKey(h => h.EventRoomId);

            builder
                .HasOne(h => h.Person)
                .WithMany(w => w.PersonEventRoomAssociations)
                .HasForeignKey(h => h.PersonId);
        }

        private static class PersonEventRoomAssociationNames
        {
            public const string Table = "PersonEventRoom";
            public const string EventRoomId = "EventRoomId";
            public const string PersonId = "PersonId";
        }
    }
}