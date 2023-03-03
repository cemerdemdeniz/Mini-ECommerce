using ECommerceAPI.Application.Repositories;
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

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;

        readonly private IOrderReadRepository _orderReadRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository , IOrderWriteRepository orderWriteRepository,ICustomerWriteRepository customerWriteRepository,IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository; 
        }

        [HttpGet]
        public async Task Get()
        {

           Order order = await _orderReadRepository.GetByIdAsync("5c9c6650-55c3-453e-a902-b93012b94d7d");
            order.Address = "Istanbul";
           await _orderWriteRepository.SaveAsync();


        }


    }
}
