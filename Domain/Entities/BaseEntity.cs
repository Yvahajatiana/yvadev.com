using System;
using System.Collections.Generic;
using System.Text;

namespace Yvadev.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime ModificationDate { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
