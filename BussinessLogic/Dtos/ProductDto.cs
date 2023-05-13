using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Discout { get; set; }
        public string? ImageUrl { get; set; }
        public bool InStock { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
