namespace Yvadev.Infrastructure.EF.Maps
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Yvadev.Domain.Entities;

    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Id);
            entityTypeBuilder.HasIndex(t => t.UserName).IsUnique();
            entityTypeBuilder.HasIndex(t => t.UserNameId).IsUnique();
            entityTypeBuilder.Property(t => t.Email);
            entityTypeBuilder.Property(t => t.PhoneNumber);
            entityTypeBuilder.Property(t => t.FirstName);
            entityTypeBuilder.Property(t => t.LastName);
            entityTypeBuilder.Property(t => t.PostalCode);
            entityTypeBuilder.Property(t => t.ModificationDate);
            entityTypeBuilder.Property(t => t.CreationDate);
        }
    }
}
