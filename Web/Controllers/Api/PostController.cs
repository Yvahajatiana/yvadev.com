using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yvadev.Domain.Contracts;
using Yvadev.Domain.Entities;
using Yvadev.Web.Contracts;
using Yvadev.Web.ViewModels;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IPostUIService postUIService;

        public PostController(IPostService postService, IPostUIService postUIService)
        {
            this.postService = postService;
            this.postUIService = postUIService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var posts = postService.GetPosts();
            return Json(posts);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(long Id)
        {
            var post = postService.GetPost(Id);
            return Json(post);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreatePostRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            postUIService.CreatePost(model);
            return Ok("SUCCESS");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdatePostRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            postUIService.UpdatePost(model);
            return Ok("SUCCESS");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            postService.DeletePost(Id);
            return Ok();
        }
    }
}