﻿using AutoMapper;
using BussinessLogic.ApplicationExceptions;
using BussinessLogic.Dtos;
using BussinessLogic.Interfaces;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public ProductsService(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await context.Products.Include(p => p.Category).ToListAsync();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task<ProductDto?> Get(int id)
        {
            if (id < 0) throw new HttpException("ID must be greater or equals to 0!", HttpStatusCode.BadRequest); // Bad Request: 400

            var product = await context.Products.FindAsync(id) ?? throw new HttpException("Product with your ID not found!", HttpStatusCode.NotFound);

            // convert to ProductDto
            //return new ProductDto()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    Discout = product.Discout,
            //    InStock = product.InStock,
            //    ImageUrl = product.ImageUrl,
            //    CategoryId = product.CategoryId,
            //    CategoryName = product.Category?.Name,
            //};

            // map to ProductDto
            return mapper.Map<ProductDto>(product);
        }

        public async Task Create(ProductDto product)
        {
            context.Products.Add(mapper.Map<Product>(product));
            await context.SaveChangesAsync();
        }

        public async Task Edit(ProductDto product)
        {
            context.Products.Update(mapper.Map<Product>(product));
            await context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await this.Get(id);

            if (product == null) throw new HttpException("Product with your ID not found!", HttpStatusCode.NotFound); // NotFound 404

            context.Products.Remove(mapper.Map<Product>(product));
            await context.SaveChangesAsync();
        }
    }
}
