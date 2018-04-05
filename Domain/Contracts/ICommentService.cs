namespace Yvadev.Domain.Contracts
{
    using System.Collections.Generic;
    using Yvadev.Domain.Entities;

    public interface ICommentService
    {
        List<Comment> GetComments(Post post);

        Comment GetComment(long id);

        void CreateComment(Comment comment);

        void UpdateComment(Comment comment);

        void DeleteComment(long id);
    }
}
