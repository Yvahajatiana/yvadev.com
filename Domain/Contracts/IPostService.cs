namespace Yvadev.Domain.Contracts
{
    using System.Collections.Generic;
    using Yvadev.Domain.Entities;

    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPost(long id);

        void CreatePost(Post post);

        void UpdatePost(Post post);

        void DeletePost(long id);
    }
}
