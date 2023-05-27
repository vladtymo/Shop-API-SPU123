using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Dtos
{
    public class TestCreateModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public IFormFile Image { get; set; }
    }
}
