using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Yvadev.Domain.Contracts;
using Yvadev.Domain.Entities;
using Yvadev.Infrastructure.EF.Contexts;
using Yvadev.Infrastructure.EF.Repositories;

namespace DomainTest
{
    public class PostRepositorynIntegrationTest
    {
        private readonly IRepository<Post> repository;
        private readonly ApplicationContext context;

        public PostRepositorynIntegrationTest()
        {
            var connectionString = new WebHostBuilder().UseContentRoot(Directory.GetCurrentDirectory()).GetSetting("ConnectionStrings");
            var options = new DbContextOptionsBuilder<ApplicationContext>();
            
        }

        [Fact]
        public void AddPost_Success()
        {
            var user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "Adress",
                Email = "MyEmail",
                CreationDate = DateTime.UtcNow,
                PhoneNumber = "45656",
                UserName = "userName",
                PostalCode = "456"
            };

            var post = new Post
            {
                Content = "Content",
                CreationDate = DateTime.UtcNow,
                Title = "Title",
                Author = user,
                IsPublished = PublicationStatus.Unpublished
            };
            repository.Add(post);
            var posts = context.Set<Post>();
            Assert.True(posts.Any());
        }
    }
}
