using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> validator;
        private readonly APIContext context;

        public ProductsController(IValidator<Product> validator, APIContext context)
        {
            this.validator = validator;
            this.context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = context.Products.ToList();
            return Ok(values);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = context.Products.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = validator.Validate(product);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

            context.Products.Add(product);
            context.SaveChanges();
            return Ok("Product added successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return Ok("Product deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = validator.Validate(product);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
;
            context.Products.Update(product);
            context.SaveChanges();
            return Ok("Product updated successfully.");
        }
    }
}