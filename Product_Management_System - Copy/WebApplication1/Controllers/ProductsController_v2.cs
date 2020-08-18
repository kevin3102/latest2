using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Managment_System.Data;
using Product_Managment_System.Models;
using Product_Managment_System.Repository;
using Product_Managment_System.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product_Managment_System.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController_v2 : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductsController_v2(IProductService productservice)
        {
            _productservice = productservice;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productservice.GetProducts();
        }

        // GET: api/Products/{id}
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productservice.GetProduct(id);
        }


        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product productdetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var product = await _productservice.AddProduct(productdetails);
                if (product == 0)
                {
                    return Ok("Product registration successful");
                }
                else
                {
                    return NotFound("Invalid product id");
                }
            }

        }
    }
}
