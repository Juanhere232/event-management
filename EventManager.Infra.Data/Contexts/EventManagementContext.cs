using System.Diagnostics.CodeAnalysis;
using EventManager.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infra.Data.Contexts
{
    [ExcludeFromCodeCoverage]
    public class EventManagementContext : DbContext
    {
        public EventManagementContext(
            DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CoffeePlaceMapping());
            builder.ApplyConfiguration(new EventRoomMapping());
            builder.ApplyConfiguration(new PersonMapping());
            builder.ApplyConfiguration(new PersonCoffeePlaceAssociationMapping());
            builder.ApplyConfiguration(new PersonEventRoomAssociationMapping());

            base.OnModelCreating(builder);
        }
    }
}