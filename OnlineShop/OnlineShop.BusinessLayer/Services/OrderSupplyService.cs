using Dapper;
using OnlineShop.BusinessLayer.DTOs;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.EntityServices;

namespace OnlineShop.BusinessLayer.Services
{
    public class OrderSupplyService
    {
        private InputManager inputManager = new();
        private OutputManager outputManager = new();
        private IDGenerator idGenerator = new();
        private InputValidator inputValidator = new();
        private CommonEntityService<OrderSupply> commonEntityService = new();
        private SuppliersService suppliersService = new();
        private ProductsService productsService = new();
        private EmployeeService employeeService = new();
        private List<OrderSupply> orderSupply = new List<OrderSupply>();
        private DapperContext dapperContext = new();

        public async Task<OrderSupplyDto> MakeOrderOfSupply(int supplierID, int productID, int productAmount, DateTime orderTime, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supply = (await connection.QueryAsync<OrderSupply>("MakeOrderOfSupply", new {  
                    _supplier = suppliersService.GetSupplierByID(supplierID, connectionStr),
                    _product = productsService.GetProductByID(productID, connectionStr),
                    ProductAmount = productAmount,
                    OrderTime = orderTime,
                    _employee = employeeService.GetEmployeeByID()
                })).FirstOrDefault();



                var sup = new OrderSupplyDto()
                {
                    _supplier = supply._supplier,
                    _product = supply._product,
                    ProductAmount = supply.ProductAmount,
                    OrderTime = supply.OrderTime,
                    _employee = supply._employee
                };
                return sup;
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        public async Task<OrderSupplyDto> GetSupplyOrderByID(int supplyID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supply = (await connection.QueryAsync<OrderSupply>("GetSupplyOrderByID", new { OrderSupplyID = supplyID })).FirstOrDefault();


                var sup = new OrderSupplyDto()
                {
                    _supplier = supply._supplier,
                    _product = supply._product,
                    ProductAmount = supply.ProductAmount,
                    OrderTime = supply.OrderTime,
                    _employee = supply._employee
                };
                return sup;
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
        //public async Task<int> GetAmount(int supplyAmount)
        //{
        //    //var supplyAmount = inputManager.InputAmount(inputValidator, commonEntityService.GetListType());
        //    try
        //    {
        //        var supply = orderSupply.FirstOrDefault(orderSupply => orderSupply.ProductAmount == supplyAmount);
        //        if (supply == null)
        //        {
        //            outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
        //        }
        //        else
        //        {
        //            outputManager.OutputToConsole(supply.ToString(), commonEntityService.GetListType());
        //        }
        //        return supplyAmount;
        //    }
        //    catch (Exception ex)
        //    {
        //        outputManager.OutputException(ex);
        //        throw;
        //    }
        //}
        public async Task<GetAllSuppliesDto> OutputSupplyOrders(string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var sql = $"select * FROM OrderSupply";
                var supplies = await connection.QueryAsync<OrderSupply>(sql);



                var getAllsupplies = supplies.Select(s => new OrderSupplyDto()
                {
                    _supplier = s._supplier,
                    _product = s._product,
                    ProductAmount = s.ProductAmount,
                    OrderTime = s.OrderTime,
                    _employee = s._employee
                }).ToList();


                return new GetAllSuppliesDto { Supplies = getAllsupplies };
            }
            catch (Exception ex)
            {
                outputManager.OutputException(ex);
                throw;
            }
        }
    }
}