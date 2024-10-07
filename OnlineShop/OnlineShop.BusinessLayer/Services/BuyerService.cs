using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Data.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace OnlineShop.BusinessLayer.Services
{
    public class BuyerService
    {
        private InputManager _inputManager = new();
        private InputValidator _inputValidator = new();
        private OutputManager _outputManager = new();
        private IDGenerator _generatorID = new();
        private CommonEntityService<Buyer> _commonEntityService = new();
        private DapperContext dapperContext = new();

        private List<Buyer> buyers = new List<Buyer>()
        {
           //new(1, 34334, "BuyerName1", "BuyerSurName1"),
           //new(2, 34634, "BuyerName2", "BuyerSurName2")
        };
        public Buyer CreateBuyer()
        {
            int userID = _generatorID.InputID(buyers);
            ulong inn = 11;//_inputManager.InputINN(_inputValidator, _commonEntityService.GetListType());
            string name = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            string surname = _inputManager.InputName(_inputValidator, _commonEntityService.GetListType());
            return new Buyer(userID,"email", inn, name, surname, "11111", DateOnly.MaxValue, "address");
        }
        public void AddBuyer()
        {
            buyers.Add(CreateBuyer());
            _outputManager.OutputToConsole(NotificationConstants.ADDED, _commonEntityService.GetListType());
        }
        public void RemoveBuyerID(int buyerID)
        {
            var buyer = buyers.FirstOrDefault(buyer => buyer.UserID == buyerID);
            if (buyer != null)
            {
                buyers.Remove(buyer);
                _outputManager.OutputToConsole(NotificationConstants.DELETED, _commonEntityService.GetListType());
            }
            else
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
        }
        public Buyer Updatebuyer(int buyerID)
        {
            var buyer = buyers.FirstOrDefault(buyer => buyer.UserID == buyerID);
            if (buyer == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return buyer;
        }
        public Buyer GetManufacturerByID()
        {
            var buyerID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType());
            var buyer = buyers.FirstOrDefault(buyer => buyer.UserID == buyerID);
            if (buyer == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return buyer;
        }
        public void OutputBuyers()
        {
            _outputManager.OutputToConsole(_commonEntityService.OutputList(buyers), _commonEntityService.GetListType());
        }

        public Buyer GetBuyerByID(int buyerID)
        {
            try
            {
                var _buyer = buyers.FirstOrDefault(buyer => buyer.BuyerId == buyerID);
                if (_buyer == null)
                {
                    _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
                }
                else
                {
                    _outputManager.OutputToConsole(_buyer.ToString(), _commonEntityService.GetListType());
                }
                return _buyer;
            }
            catch (Exception ex)
            {
                _outputManager.OutputException(ex);
                throw;
            }
        }
    }
}
