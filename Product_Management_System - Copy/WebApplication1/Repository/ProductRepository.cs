using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Managment_System.Data;
using Product_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Repository
{
    public class ProductRepository : IProductRepository
    {
        private SqlDbContext sqlDbContext;
        public ProductRepository(SqlDbContext productsDbContext)
        {
            this.sqlDbContext = productsDbContext;
        }

        public Product GetProduct(int id)
        {
            var product = sqlDbContext.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return sqlDbContext.Products;
        }

        public int AddProduct(Product product)
        {
            var productinfo = sqlDbContext.Products.Find(product.Id);
            if (productinfo == null)
            {
                sqlDbContext.Products.Add(product);
                sqlDbContext.SaveChanges(true);
                return 0;
            }
            else
            {
                return 1;
            }
            
        }
    }
}
