using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Yvadev.Domain.Entities;

namespace Yvadev.Infrastructure.EF.Maps
{
    public class CommentMap
    {
        public CommentMap(EntityTypeBuilder<Comment> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Content);
            entityBuilder.Property(t => t.AuthorId);
            entityBuilder.HasOne(t => t.Post);
            entityBuilder.Property(t => t.CreationDate);
            entityBuilder.Property(t => t.ModificationDate);
        }
    }
}
