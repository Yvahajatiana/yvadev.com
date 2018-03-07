namespace Yvadev.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string Tags { get; set; }

        public virtual SEO Seo { get; set; }

    }
}
