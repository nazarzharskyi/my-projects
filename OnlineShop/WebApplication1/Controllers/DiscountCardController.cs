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
    public class DiscountCardController : ControllerBase
    {
        private DiscountCardService _discountCardService;
        private IConfiguration _configuration;
        public DiscountCardController(IConfiguration configuration, DiscountCardService discountCardService)
        {
            _discountCardService = discountCardService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("cards")]
        public async Task<GetCardDto> CreateCard([FromBody] CreateCardDto cardDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var card = await _discountCardService.CreateCard(cardDto.DiscountPercantage, cardDto.buyerId, connectionString);
            return card;
        }

        [HttpGet]
        [Route("cards/{id}")]
        public async Task<GetCardDto> GetCardById([FromRoute] GetCardByIdDto cardDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var card = await _discountCardService.GetDiscountCardByID(cardDto.id, connectionString);
            return card;
        }

        [HttpGet]
        [Route("cards")]
        public async Task<GetAllCardsDto> GetAll()
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var cards = await _discountCardService.GetDiscountCards(connectionString);
            return cards;
        }

        [HttpPut]
        [Route("cards/{id}")]
        public async Task<GetCardDto> UpdateCard([FromBody] UpdateCardDto updateCard)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var card = await _discountCardService.CreateCard(updateCard.DiscountPercantage, updateCard.buyerID, connectionString);
            return card;
        }
    }
}
