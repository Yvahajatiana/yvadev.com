namespace Yvadev.Infrastructure.EF.Maps
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Yvadev.Domain.Entities;

    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title);
            entityBuilder.Property(t => t.Content);
            entityBuilder.HasOne(t => t.Author);
            entityBuilder.Property(t => t.Tags);
            entityBuilder.HasOne(t => t.Seo);
            entityBuilder.Property(t => t.CreationDate);
            entityBuilder.Property(t => t.ModificationDate);
        }
    }
}
