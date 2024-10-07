using Dapper;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.Constants;
using OnlineShop.Entities;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Records;
using Microsoft.Data.SqlClient;
using OnlineShop.BusinessLayer.DTOs;

namespace OnlineShop.BusinessLayer.Services
{
    public class SuppliersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Supplier> commonEntityService = new();
        private ActivityLogService logService = new ActivityLogService();
        private List<Supplier> suppliers = new List<Supplier>();
        private DapperContext dapperContext = new();

        public async Task<GetSupplierDto> CreateSupplier(string name, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = (await connection.QueryAsync<Supplier>("CreateSupplier", new { SupplierName = name, SupplierEDRPOU = code })).FirstOrDefault();

                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.ADDED, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);


                var getSupplierDto = new GetSupplierDto()
                {
                      SupplierID =  supplier.SupplierID,
                      SupplierName = supplier.SupplierName,
                      SupplierEDRPOU = supplier.SupplierEDRPOU,
                };

                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            }
        }


        public async Task<GetSupplierDto> GetSupplierByID(int id, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = (await connection.QueryAsync<Supplier>("GetSupplierByID", new { SupplierID = id })).FirstOrDefault();
                if (supplier == null)
                {
                    throw new KeyNotFoundException($"Supplier with ID {id} not found.");
                }
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);

                var getSupplierDto = new GetSupplierDto()
                {
                    SupplierEDRPOU = supplier.SupplierEDRPOU,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID,
                };
                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<GetSupplierDto> GetSupplierByName(string name, string connectionStr)

        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = (await connection.QueryAsync<Supplier>("GetSupplierByName", new { SupplierName = name })).FirstOrDefault();
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);// output result to log
                await logService.OutputLog(log);

                var getSupplierDto = new GetSupplierDto()
                {
                    SupplierEDRPOU = supplier.SupplierEDRPOU,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID,
                };
                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }


        public async Task<GetSupplierDto> GetSupplierByCode(string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = (await connection.QueryAsync<Supplier>("GetSupplierByCode", new { SupplierEDRPOU = code })).FirstOrDefault();
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.GET, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);

                var getSupplierDto = new GetSupplierDto()
                {
                    SupplierEDRPOU = supplier.SupplierEDRPOU,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID,
                };
                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<GetSupplierDto> UpdateSupplierNameByID(int id, string name, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = (await connection.QueryAsync<Supplier>("UpdateSupplierName", new { SupplierID = id, SupplierName = name })).FirstOrDefault();
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);

                var getSupplierDto = new GetSupplierDto()
                {
                    SupplierEDRPOU = supplier.SupplierEDRPOU,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID,
                };

                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }

        public async Task<GetSupplierDto> UpdateSupplierCodeByID(int id, string code, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var supplier = (await connection.QueryAsync<Supplier>("UpdateSupplierEDRPOU", new { SupplierID = id, SupplierEDRPOU = code })).FirstOrDefault();
                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.UPDATE, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);

                if (supplier == null)
                {
                    throw new Exception("Supplier not found.");
                }

                var getSupplierDto = new GetSupplierDto()
                {
                    SupplierEDRPOU = supplier.SupplierEDRPOU,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID,
                };

                return getSupplierDto;
            }
            catch (Exception ex)
            {
                outputManager.OutputDBException(ex);
                throw;
            };
        }
        public async Task<string> DeleteSupplierByID(int supplierID, string connectionStr)
        {
            try
            {
                var connection = dapperContext.OpenConnection(connectionStr);
                var result = await connection.ExecuteAsync("DeleteSupplierByID", new { SupplierID = supplierID });

                ActivityLog log = new ActivityLog(DateTime.Now, NotificationConstants.DELETED, commonEntityService.GetListType()); // create log record
                await logService.OutputLog(log);

                if (result > 0)
                {
                    return "The supplier has been successfully deleted";
                }
                else
                {
                    return "Failed to remove supplier. This ID may not exist.";
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

        public async Task<GetAllSuppliersDto> GetAllSuppliers(string connectionStr)
        {
            var connection = dapperContext.OpenConnection(connectionStr);
            var sql = "SELECT * FROM Supplier";
            var suppliers = await connection.QueryAsync<Supplier>(sql);

            var getAllsuppliersDto = suppliers.Select(s => new GetSupplierDto
            {
                SupplierID = s.SupplierID,
                SupplierName = s.SupplierName,
                SupplierEDRPOU = s.SupplierEDRPOU
            }).ToList();


            return new GetAllSuppliersDto { Suppliers = getAllsuppliersDto };
        }
    }
}