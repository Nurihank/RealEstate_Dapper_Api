﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

      /*  [HttpGet]

        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductsAsync();
            return Ok(values);
        }*/

        [HttpGet]
        public async Task<IActionResult> ProductWithCategoryNameList()
        {
            var values = await _productRepository.GetAllProductsWithCategoryAsync();
            return Ok(values);
        }
    }
}
