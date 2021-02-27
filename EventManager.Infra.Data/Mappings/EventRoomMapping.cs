using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infra.Data.Mappings
{
    [ExcludeFromCodeCoverage]
    public class EventRoomMapping : IEntityTypeConfiguration<EventRoom>
    {
        public void Configure(EntityTypeBuilder<EventRoom> builder)
        {
            builder
                .ToTable(EventRoomNames.Table);

            builder
                .HasKey(h => h.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName(EventRoomNames.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(p => p.Name)
                .HasColumnName(EventRoomNames.Name)
                .HasMaxLength(EventRoom.Constraints.NameMaxLength)
                .IsRequired();
            builder
                .Property(p => p.Capacity)
                .HasColumnName(EventRoomNames.Capacity)
                .IsRequired();
        }

        private static class EventRoomNames
        {
            public const string Table = "EventRooms";
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Capacity = "Capacity";
        }
    }
}