using System;
using System.Collections.Generic;
using System.Text;
using Yvadev.Domain.Entities;

namespace Yvadev.Domain.Contracts
{
    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPost(long id);

        void CreatePost(Post post);

        void UpdatePost(Post post);

        void DeletePost(long id);
    }
}
