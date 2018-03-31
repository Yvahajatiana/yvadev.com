namespace Yvadev.Infrastructure.EF.Maps
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Yvadev.Domain.Entities;

    public class SEOMap
    {
        public SEOMap(EntityTypeBuilder<SEO> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.MetaTitle);
            entityBuilder.Property(t => t.MetaDescription);
        }
    }
}
