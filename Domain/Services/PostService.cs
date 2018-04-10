namespace Yvadev.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;

    public class PostService : IPostService
    {
        private readonly IAsyncRepository<Post> asyncRepository;
        private readonly IRepository<Post> repository;

        public PostService(IAsyncRepository<Post> asyncRepository, IRepository<Post> repository)
        {
            this.asyncRepository = asyncRepository;
            this.repository = repository;
        }

        public void CreatePost(Post post)
        {
            post.CreationDate = DateTime.UtcNow;
            repository.Add(post);
        }

        public void DeletePost(long id)
        {
            var post = repository.Get(id);
            repository.Delete(post);
        }

        public Post GetPost(long id)
        {
            return repository.Get(id);
        }

        public List<Post> GetPosts()
        {
            return repository.GetAll();
        }

        public void UpdatePost(Post post)
        {
            repository.Update(post);
        }
    }
}
