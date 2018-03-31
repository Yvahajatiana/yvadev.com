namespace Yvadev.Domain.Entities
{
    using System;

    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime ModificationDate { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
