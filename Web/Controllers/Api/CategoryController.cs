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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var categories = categoryService.GetCategories();
            return Json(categories);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(long Id)
        {
            var category = categoryService.GetCategory(Id);
            return Json(category);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            categoryService.CreateCategory(category);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            categoryService.DeleteCategory(Id);
            return Ok();
        }
    }
}