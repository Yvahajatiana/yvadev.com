namespace Yvadev.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;

    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> repository;
        private readonly IAsyncRepository<Comment> asyncRepository;

        public CommentService(IRepository<Comment> repository, IAsyncRepository<Comment> asyncRepository)
        {
            this.repository = repository;
            this.asyncRepository = asyncRepository;
        }

        public void CreateComment(Comment comment)
        {
            comment.CreationDate = DateTime.UtcNow;
            repository.Add(comment);
        }

        public void DeleteComment(long id)
        {
            var comment = repository.Get(id);
            repository.Delete(comment);
        }

        public Comment GetComment(long id)
        {
            var comment = repository.Get(id);
            return comment;
        }

        public List<Comment> GetComments(Post post)
        {
            var comments = repository.GetAll(x => x.Post.Id == post.Id);
            return comments;
        }

        public void UpdateComment(Comment comment)
        {
            repository.Update(comment);
        }
    }
}
