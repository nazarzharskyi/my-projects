using Microsoft.AspNetCore.Mvc;
using OnlineShop.BusinessLayer.DTOs;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Entities;
using OnlineShop.WebApi.DTOs;

namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private SuppliersService _suppliersService;
        private IConfiguration _configuration;
        public SuppliersController(IConfiguration configuration, SuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("suppliers")]
        public async Task<GetSupplierDto> CreateSupplier([FromBody] CleateSupplierDto supplierDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var supplier = await _suppliersService.CreateSupplier(supplierDto.Name, supplierDto.Code, connectionString);
            return supplier;
        }

        [HttpGet]
        [Route("suppliers")]
        public async Task<GetAllSuppliersDto> GetAll()
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var suppliers = await _suppliersService.GetAllSuppliers(connectionString);
            return suppliers;
        }

        [HttpGet]
        [Route("suppliers/{id}")]
        public async Task<GetSupplierDto> GetSupplierById([FromRoute] GetSupplierByIdDto supplierDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var supplier = await _suppliersService.GetSupplierByID(supplierDto.id, connectionString);
            return supplier;
        }

        [HttpGet]
        [Route("suppliers/params")]
        public async Task<GetSupplierDto> GetSupplierByParams([FromQuery] GetSupplierByParamsDto supplierDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");

            try
            {
                if (!string.IsNullOrEmpty(supplierDto.Name))
                {
                    var supplier = await _suppliersService.GetSupplierByName(supplierDto.Name, connectionString);
                    return supplier;
                }
                else if (!string.IsNullOrEmpty(supplierDto.Code))
                {
                    var supplier = await _suppliersService.GetSupplierByCode(supplierDto.Code, connectionString);
                    return supplier;
                }
                else
                {
                    throw new ArgumentException("Either 'Name' or 'Code' must be provided.");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPut]
        [Route("suppliers/{id}")]
        public async Task<GetSupplierDto> UpdateSupplierCodeByID([FromBody] UpdateSupplierDto supplierDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            var supplier = await _suppliersService.UpdateSupplierCodeByID(supplierDto.id, supplierDto.Code, connectionString);
            return supplier;
        }

        [HttpDelete]
        [Route("suppliers/{id}")]
        public async Task DeleteSupplierByID([FromRoute] GetSupplierByIdDto supplierDto)
        {
            var connectionString = _configuration.GetConnectionString("Master");
            await _suppliersService.DeleteSupplierByID(supplierDto.id, connectionString);
        }
    }
}

