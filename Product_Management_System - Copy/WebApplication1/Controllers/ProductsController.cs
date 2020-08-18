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

namespace Product_Managment_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductsController(IProductService productservice)
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
        [HttpGet("{id}",Name= "GetProduct")]
        public async Task<Product> GetProduct(int id)
        {
            return  await _productservice.GetProduct(id);
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
                var product =  await _productservice.AddProduct(productdetails);
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
