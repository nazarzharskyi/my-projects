using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace ConsoleApp1
{
    internal class DiscountCardConsoleFlow
    {
        DiscountCardService discountCardService = new();
        InputManager inputManager = new();
        InputValidator inputValidator = new();
        CommonEntityService<DiscountCard> commonEntityService = new();
        DiscountCard discountCard = new();
        OutputManager outputManager = new();

        //1
        public async Task CreateCard(string connectionString)
        {
            await discountCardService.CreateCard(inputManager.InputDiscountPercantage(inputValidator, commonEntityService.GetListType()), 
                inputManager.InputID(inputValidator, commonEntityService.GetListType()), connectionString);
        }

        //2
        public async Task updateCardPercantage(string connectionString)
        {
            outputManager.OutputToConsoleWrite($"Enter Discount Card ID to update percantage: ");
            int cardID = inputManager.InputID(inputValidator, commonEntityService.GetListType());
            outputManager.OutputToConsoleWrite($"Enter new Disount percantage to update: ");
            double percantage = inputManager.InputDiscountPercantage(inputValidator, commonEntityService.GetListType());
            discountCard = await discountCardService.UpdateCardPercantage(cardID, percantage, connectionString);
            if (discountCard != null)
            {
                outputManager.OutputToConsoleWrite("Updated Card: ");
                outputManager.OutputToConsole(discountCard.ToString(), commonEntityService.GetListType());
            }
            else
            {
                outputManager.OutputToConsoleWriteLn("Card not found.");
            }
        }

        //3
        public async Task GetAllDiscountCards(string connectionString)
        {
            var discountCards = await discountCardService.GetDiscountCards(connectionString);
            outputManager.OutputToConsole(commonEntityService.OutputList(discountCards), commonEntityService.GetListType()); ;
        }

        //4
        public async Task GetDiscountCardById(string connectionString)
        {
            discountCard = await discountCardService.GetDiscountCardByID(inputManager.InputID(inputValidator, commonEntityService.GetListType()), connectionString);
            if (discountCard != null)
            {
                outputManager.OutputToConsoleWriteLn(discountCard.ToString());
            }
            else
            {
                outputManager.OutputToConsoleWriteLn("Manufacturer not found.");
            }
        }
    }
}