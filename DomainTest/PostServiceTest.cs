using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Yvadev.Domain.Contracts;
using Yvadev.Domain.Entities;
using Yvadev.Domain.Services;
using Xunit;
using System.Linq;

namespace DomainTest
{
    public class PostServiceTest
    {
        private Mock<IRepository<Post>> mockRepository;
        private Mock<IAsyncRepository<Post>> mockAsyncRepository;
        private IPostService postService;

        public PostServiceTest()
        {
            mockRepository = new Mock<IRepository<Post>>();
            mockAsyncRepository = new Mock<IAsyncRepository<Post>>();
            postService = new PostService(mockAsyncRepository.Object, mockRepository.Object);
        }

        [Fact]
        public void GetPosts_Return_Any()
        {
            mockRepository.Setup(mRep => mRep.GetAll())
                .Returns(new List<Post>
                {
                    new Post {Id=0,Title="Post 1",Author="Author 1",Content="Content1",Tags="Tags"},
                    new Post {Id=1,Title="Post 2",Author="Author 2",Content="Content2",Tags="Tags"},
                    new Post {Id=2,Title="Post 3",Author="Author 3",Content="Content3",Tags="Tags"},
                    new Post {Id=3,Title="Post 4",Author="Author 4",Content="Content4",Tags="Tags"}
                });
            
            var results = postService.GetPosts();
            Assert.True(results.Any());
        }

        [Fact]
        public void GetPost_ReturnOne()
        {
            mockRepository.Setup(mRep => mRep.Get(0))
                .Returns(new Post
                { Id = 0, Title = "Post 1", Author = "Author 1", Content = "Content1", Tags = "Tags" });
            
            var result = postService.GetPost(0);
            Assert.True(result != null && result.Id == 0);
        }

        [Fact]
        public void UpdatePost_Success()
        {
            var data = new Post { Id = 0, Title = "Post 1", Author = "Author 1", Content = "Content1", Tags = "Tags" };
            var datas = new List<Post>
                {
                    new Post {Id=0,Title="Post 1",Author="Author 1",Content="Content1",Tags="Tags"},
                    new Post {Id=1,Title="Post 2",Author="Author 2",Content="Content2",Tags="Tags"},
                    new Post {Id=2,Title="Post 3",Author="Author 3",Content="Content3",Tags="Tags"},
                    new Post {Id=3,Title="Post 4",Author="Author 4",Content="Content4",Tags="Tags"}
                };
            mockRepository.Setup(mRep => mRep.Update(data)).Callback((Post post)=> { datas.Remove(post); });
            postService.UpdatePost(data);
            var result = datas.SingleOrDefault(x => x.Id == data.Id);
            Assert.True(result != null);
        }

        [Fact]
        public void CreatePost_Success()
        {
            var data = new Post { Id = 4, Title = "Post 1", Author = "Author 1", Content = "Content1", Tags = "Tags" };
            var datas = new List<Post>
                {
                    new Post {Id=0,Title="Post 1",Author="Author 1",Content="Content1",Tags="Tags"},
                    new Post {Id=1,Title="Post 2",Author="Author 2",Content="Content2",Tags="Tags"},
                    new Post {Id=2,Title="Post 3",Author="Author 3",Content="Content3",Tags="Tags"},
                    new Post {Id=3,Title="Post 4",Author="Author 4",Content="Content4",Tags="Tags"}
                };
            mockRepository.Setup(mRep => mRep.Add(data)).Callback((Post post) => { datas.Add(post); });
            postService.CreatePost(data);
            var result = datas.SingleOrDefault(x => x.Id == data.Id);
            Assert.True(result != null);
        }

        [Fact]
        public void DeletePost_Success()
        {
            var data = new Post { Id = 4, Title = "Post 1", Author = "Author 1", Content = "Content1", Tags = "Tags" };
            var datas = new List<Post>
                {
                    new Post {Id=0,Title="Post 1",Author="Author 1",Content="Content1",Tags="Tags"},
                    new Post {Id=1,Title="Post 2",Author="Author 2",Content="Content2",Tags="Tags"},
                    new Post {Id=2,Title="Post 3",Author="Author 3",Content="Content3",Tags="Tags"},
                    new Post {Id=3,Title="Post 4",Author="Author 4",Content="Content4",Tags="Tags"}
                };
            mockRepository.Setup(mRep => mRep.Add(data)).Callback((Post post) => { datas.Remove(post); });
            postService.DeletePost(data.Id);
            var result = datas.SingleOrDefault(x => x.Id == data.Id);
            Assert.True(result == null);
        }
    }
}
