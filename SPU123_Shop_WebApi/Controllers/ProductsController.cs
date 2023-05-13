using BussinessLogic.Dtos;
using BussinessLogic.Interfaces;
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
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]                       // GET: ~/api/products
        //[HttpGet("all")]              // GET: ~/api/products/all
        //[HttpGet("/all-products")]    // GET: ~/all-products
        public async Task<IActionResult> Get()
        {
            // get all products 
            return Ok(await productsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return Ok(await productsService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            // TODO: move to the Logic layer
            if (!ModelState.IsValid) return BadRequest();

            await productsService.Create(product);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ProductDto product)
        {
            if (!ModelState.IsValid) return BadRequest();

            await productsService.Edit(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productsService.Delete(id);

            return Ok();
        }
    }
}
