namespace Yvadev.Domain.Entities
{
    using System;

    public abstract class Publishable : BaseEntity
    {
        public DateTime PublicationDate { get ; set; }

        public PublicationStatus IsPublished { get; set; }

        public virtual User Author { get; set; }
    }
}
