using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yvadev.Domain.Contracts;
using Yvadev.Domain.Entities;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
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
        public IActionResult Create([FromBody] Post post)
        {
            if (!ModelState.IsValid) return BadRequest();
            postService.CreatePost(post);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Post post)
        {
            if (!ModelState.IsValid) return BadRequest();
            postService.UpdatePost(post);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            postService.DeletePost(Id);
            return Ok();
        }
    }
}