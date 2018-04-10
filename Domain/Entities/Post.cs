namespace Yvadev.Domain.Entities
{
    public class Post : Publishable
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Tags { get; set; }
    }
}
