using System.Diagnostics.CodeAnalysis;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infra.Data.Mappings
{
    [ExcludeFromCodeCoverage]
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable(PersonNames.Table);

            builder
                .HasKey(h => h.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName(PersonNames.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(p => p.FirstName)
                .HasColumnName(PersonNames.FirstName)
                .HasMaxLength(Person.Constraints.FirstNameMaxLength)
                .IsRequired();
            builder
                .Property(p => p.LastName)
                .HasColumnName(PersonNames.LastName)
                .HasMaxLength(Person.Constraints.LastNameMaxLength)
                .IsRequired();
        }

        private static class PersonNames
        {
            public const string Table = "Persons";
            public const string Id = "Id";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
        }
    }
}