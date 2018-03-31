namespace Yvadev.Domain.Entities
{
    public class Comment : Publishable
    {
        public virtual Post Post { get; set; }

        public string Content { get; set; }

        public long ParentId { get; set; }
    }
}
