﻿using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            // await _productWriteRepository.AddRangeAsync(new() {
            //     new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10, },
            //     new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 20, },
            //     new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 100, }
            // });
            //await _productWriteRepository.SaveAsync();

           Product p = await _productReadRepository.GetByIdAsync("7e0164ce-25e8-4afa-9d8a-545451d048d1");
            p.Name = "Ahmet";
           await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
       
    }
}
