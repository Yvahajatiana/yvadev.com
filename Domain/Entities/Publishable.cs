using System;
using System.Collections.Generic;
using System.Text;

namespace Yvadev.Domain.Entities
{
    public abstract class Publishable : BaseEntity
    {
        public DateTime PublicationDate { get; set; }

        public PublicationStatus IsPublished { get; set; }

        public virtual User Author { get; set; }
    }
}
