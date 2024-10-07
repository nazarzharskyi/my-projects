using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using Microsoft.Data.SqlClient;

namespace OnlineShop.BusinessLayer.Services
{
    public class ManufacturersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Manufacturer> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
        private List<Manufacturer> manufacturers = new List<Manufacturer>();
        private DapperContext dapperContext = new();


        public async Task<Manufacturer> CreateManufacturer(string name, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = await connection.QueryAsync<Manufacturer>("CreateManufacturer", new { ManufacturerName = name, ManufacturerEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Manufacturer> GetManufacturerByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = await connection.QueryAsync<Manufacturer>("GetManufacturerByID", new { ManufacturerID = id });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Manufacturer> GetManufacturerByName(string name, string connectionStr)


        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = await connection.QueryAsync<Manufacturer>("GetManufacturerByName", new { ManufacturerName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public async Task<Manufacturer> GetManufacturerByCode(string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = await connection.QueryAsync<Manufacturer>("GetManufacturerByCode", new { ManufacturerEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Manufacturer> UpdateManufacturerNameByID(int id, string name, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = await connection.QueryAsync<Manufacturer>("UpdateManufacturerName", new { ManufacturerID = id, ManufacturerName = name });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<Manufacturer> UpdateManufacturerCodeByID(int id, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var manufacturer = await connection.QueryAsync<Manufacturer>("UpdateManufacturerEDRPOU", new { ManufacturerID = id, ManufacturerEDRPOU = code });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                return manufacturer.FirstOrDefault();
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public async Task<string> DeleteManufacturerByID(int ManufacturerID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var result = await connection.ExecuteAsync("DeleteManufacturerByID", new { ManufacturerID = ManufacturerID });
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);
                if (result > 0)
                {
                    return "The Manufacturer has been successfully deleted";
                }
                else
                {
                    return "Failed to remove Manufacturer. This ID may not exist.";
                }
            }
            catch (SqlException ex)
            {
                return $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<List<Manufacturer>> GetAllManufacturers(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = $"select * FROM Manufacturer";
            var manufacturers = await connection.QueryAsync<Manufacturer>(sql);
            return manufacturers.ToList();
        }
    }
}