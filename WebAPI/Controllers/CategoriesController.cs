using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly APIContext context;
        public CategoriesController(APIContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var values = context.Categories.Find(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Createcategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok("Category added successfully.");
        }

        [HttpDelete]
        public IActionResult Deletecategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return Ok("Category deleted successfully.");

        }

        [HttpPut]
        public IActionResult Putcategory(Category category)
        {
            var values = context.Categories.Update(category);
            context.SaveChanges();
            return Ok("Category updated successfully.");
        }
    }
}
