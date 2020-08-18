using Microsoft.AspNetCore.Mvc;
using Product_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int Id);
        int AddProduct(Product product);
    }
}
