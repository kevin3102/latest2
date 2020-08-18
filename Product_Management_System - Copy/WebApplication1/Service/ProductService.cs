using Product_Managment_System.Models;
using Product_Managment_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async  Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult<IEnumerable<Product>>(_productRepository.GetProducts());
        }

        public async Task<Product> GetProduct(int id)
        {
            return await Task.FromResult <Product>( _productRepository.GetProduct(id));
        }

        public async Task<int> AddProduct(Product productdetails)
        {
            return await Task.FromResult <int > (_productRepository.AddProduct(productdetails));
                 
        }
    }


}

