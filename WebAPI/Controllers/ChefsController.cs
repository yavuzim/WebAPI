using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly APIContext context;
        public ChefsController(APIContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult ChefsList()
        {
            var values = context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            var values = context.Chefs.Add(chef);
            context.SaveChanges();
            return Ok("Chef added successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var values = context.Chefs.Find(id);
            context.Chefs.Remove(values);
            context.SaveChanges();
            return Ok("Chef deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            var values = context.Chefs.Update(chef);
            context.SaveChanges();
            return Ok("Chef updated successfully.");
        }
    }
}
