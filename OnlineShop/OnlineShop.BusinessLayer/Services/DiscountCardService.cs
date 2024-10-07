using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using Dapper;
using Microsoft.Data.SqlClient;
using OnlineShop.Records;
using OnlineShop.BusinessLayer.DTOs;
using OnlineShop.Data.Entities;
using System;

namespace OnlineShop.BusinessLayer.Services
{
    public class DiscountCardService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<DiscountCard> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
        private BuyerService buyerService = new();
        private DapperContext dapperContext = new();
        private List<DiscountCard> discountCard = new List<DiscountCard>();

        public async Task<GetCardDto> CreateCard(double discountPercantage, int buyerID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var _discountCard = (await connection.QueryAsync<DiscountCard>("CreateCard", new { PercantageDiscount = discountPercantage, 
                    buyer = buyerService.GetBuyerByID(buyerID) })).FirstOrDefault();


                var getCardDto = new GetCardDto()
                {
                    PercanatageDiscount = _discountCard.PercanatageDiscount,
                    buyer = _discountCard.buyer
                };

                return getCardDto;
            }
            catch(SqlException ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task AddCard(int cardID, double discountPercantage)
        //{
        //    discountCard.Add(await CreateCard(cardID, discountPercantage));
        //    outputManager.OutputToConsole(NotificationConstants.CARD_IS_SUCESSFULLY_ADDED, commonEntityService.GetListType());
        //}
        public async Task<GetCardDto> UpdateCardPercantage(int cardID, double percantage, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var card = (await connection.QueryAsync<DiscountCard>("UpdateCardPercantage", new { DiscountCard_ID = cardID, PercanatageDiscount = percantage })).FirstOrDefault();
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType());
                await logService.OutputLog(log);

                var getCardDto = new GetCardDto()
                {
                    DiscountCard_ID = card.DiscountCard_ID,
                    PercanatageDiscount = card.PercanatageDiscount
                };

                return getCardDto;
            }
            catch (SqlException ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<GetAllCardsDto> GetDiscountCards(string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var sql = $"select * FROM DiscountCards";
                var cards = await connection.QueryAsync<DiscountCard>(sql);

                var getAllCardsDto = cards.Select(s => new GetCardDto
                {
                    DiscountCard_ID= s.DiscountCard_ID,
                    PercanatageDiscount= s.PercanatageDiscount,
                    buyer = s.buyer
                }).ToList();


                return new GetAllCardsDto { Cards = getAllCardsDto };
            }
            catch (SqlException ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<GetCardDto> GetDiscountCardByID(int cardID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var card = (await connection.QueryAsync<DiscountCard>("GetDiscountCardByID", new { DiscountCard_ID = cardID })).FirstOrDefault();

                var getCardDto = new GetCardDto()
                {
                    DiscountCard_ID = card.DiscountCard_ID,
                    PercanatageDiscount = card.PercanatageDiscount,
                    buyer = card.buyer
                };
                return getCardDto;
            }
            catch (SqlException ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
            catch ( Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
    }
}