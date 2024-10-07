using Microsoft.AspNetCore.Mvc;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.DTOs;
using OnlineShop.Data.Entities;
using OnlineShop.Entities;
using OnlineShop.EntityServices;
using OnlineShop.WebApi.DTOs;

namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    public class OrderSupplyController : ControllerBase
    {
        private OrderSupplyService _orderSupplyService;
        private IConfiguration _configuration;
        public OrderSupplyController(IConfiguration configuration, OrderSupplyService orderSupplyService)
        {
            _orderSupplyService = orderSupplyService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("orderSupply/{id}")]
        public async Task<OrderSupplyDto> GetSupplyOrderByID([FromRoute] int id)
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var supply = await _orderSupplyService.GetSupplyOrderByID(id, connectionStr);
            return supply;
        }

        [HttpPost]
        [Route("orderSupply")]
        public async Task<OrderSupplyDto> MakeOrderOfSupply([FromBody] MakeOrderOfSupplyDto makeOrderOfSupplyDto)
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var order = await _orderSupplyService.MakeOrderOfSupply(makeOrderOfSupplyDto.SupplierID, makeOrderOfSupplyDto.ProductID, makeOrderOfSupplyDto.ProductAmount,
                makeOrderOfSupplyDto.OrderTime, connectionStr);
            return order;
        }

        [HttpGet]
        [Route("orderSupply")]
        public async Task<GetAllSuppliesDto> OutputSupplyOrders()
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var supplies = await _orderSupplyService.OutputSupplyOrders(connectionStr);
            return supplies;
        }


    }
}
