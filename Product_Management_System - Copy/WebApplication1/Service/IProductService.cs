using Product_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Service
{
    public interface IProductService
    {
        Task <IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int Id);
        Task<int> AddProduct(Product product);
    }
}
