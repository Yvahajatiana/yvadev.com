using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yvadev.Domain.Contracts;
using Yvadev.Domain.Entities;
using Yvadev.Web.Contracts;
using Yvadev.Web.ViewModels;

namespace Yvadev.Web.Services
{
    public class PostUIService : IPostUIService
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public PostUIService(IPostService postService, IUserService userService, IMapper mapper)
        {
            this.postService = postService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public void CreatePost(CreatePostRequestModel model)
        {
            var post = mapper.Map<Post>(model);
            var seo = mapper.Map<SEO>(model);
            var user = userService.GetUser(model.UserId);

            post.Author = user;
            post.Seo = seo;

            postService.CreatePost(post);
        }

        public void UpdatePost(UpdatePostRequestModel model)
        {
            var post = mapper.Map<Post>(model);
            var postToUpdate = postService.GetPost(model.Id);

            var seo = mapper.Map<SEO>(model);
            var author = userService.GetUser(model.Id);

            postToUpdate.Seo = post



            postService.UpdatePost();
        }
    }
}
