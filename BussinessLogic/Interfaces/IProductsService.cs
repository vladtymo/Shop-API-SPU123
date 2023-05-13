using BussinessLogic.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto?> Get(int id);
        Task Create(ProductDto product);
        Task Edit(ProductDto product);
        Task Delete(int id);

        // other methods...
    }
}
