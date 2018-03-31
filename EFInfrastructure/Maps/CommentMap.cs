namespace Yvadev.Infrastructure.EF.Maps
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Yvadev.Domain.Entities;

    public class CommentMap
    {
        public CommentMap(EntityTypeBuilder<Comment> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Content);
            entityBuilder.HasOne(t => t.Author);
            entityBuilder.HasOne(t => t.Post);
            entityBuilder.Property(t => t.CreationDate);
            entityBuilder.Property(t => t.ModificationDate);
        }
    }
}
