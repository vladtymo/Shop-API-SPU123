using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace SPU123_Shop_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext context;

        public ProductsController(ShopDbContext context)
        {
            this.context = context;
        }

        [HttpGet]                       // GET: ~/api/products
        //[HttpGet("all")]              // GET: ~/api/products/all
        //[HttpGet("/all-products")]    // GET: ~/all-products
        public async Task<IActionResult> Get()
        {
            // get all products 
            return Ok(await context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            // get product by ID
            if (id < 0) return BadRequest();

            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Products.Update(product);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest();

            var product = await context.Products.FindAsync(id);

            if (product == null) return NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
