using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Yvadev.Domain.Entities;

namespace Yvadev.Infrastructure.EF.Maps
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title);
            entityBuilder.Property(t => t.Content);
            entityBuilder.Property(t => t.Author);
            entityBuilder.Property(t => t.Tags);
            entityBuilder.HasOne(t => t.Seo);
        }
    }
}
