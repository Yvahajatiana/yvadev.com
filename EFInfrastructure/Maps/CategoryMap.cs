namespace Yvadev.Infrastructure.EF.Maps
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Yvadev.Domain.Entities;

    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.CreationDate);
            entityBuilder.Property(t => t.ModificationDate);
        }
    }
}
