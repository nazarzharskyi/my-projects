using Microsoft.AspNetCore.Mvc;
using OnlineShop.BusinessLayer.DTOs;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using OnlineShop.Entities;
using OnlineShop.WebApi.DTOs;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private ProductStocksService _productStocksService;
        private IConfiguration _configuration;
        public ProductStockController(IConfiguration configuration, ProductStocksService productStocksService)
        {
            _productStocksService = productStocksService;
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("productStocks/{id}")]
        public async Task<int> GetAmountByID([FromBody]GetAmountByID getAmountByID)
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var amount = await _productStocksService.GetAmountByStockItemID(getAmountByID.productOnStockID, connectionStr);
            return amount;
        }


        [HttpPost]
        [Route("productStocks")]
        public async Task<GetStockDTO> CreateProductOnStock([FromBody]CreateProductOnStockDto stockDto)
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var product = await _productStocksService.CreateProductOnStock(stockDto.ProductId, stockDto.ProductAmount, stockDto.StockItemId, connectionStr);
            return product;
        }

        [HttpPut]
        [Route("productStocks")]
        public async Task<GetStockDTO> UpdateOfAmount([FromBody] UpdateOfAmountOnStockDto amount)
        {
            var connectionStr = _configuration.GetConnectionString("Master");
            var updAmount = await _productStocksService.UpdateOfAmount(amount.ProductID, amount.ProductAmount, amount.StockItemID, connectionStr);
            return updAmount;
        }
    }
}