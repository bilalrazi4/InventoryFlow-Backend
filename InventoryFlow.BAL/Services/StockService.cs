using AutoMapper;
using Azure;
using Dapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InventoryFlow.Service.Services
{
    public class StockService
    {
        private readonly UnitOfWork<Stock> _uowStock;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public StockService(UnitOfWork<Stock> _uowStock, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowStock = _uowStock;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
        }
        public async Task<ResponseDTO<StockDTO>> CreateOrUpdate(StockDTO stock)
        {
            try
            {
                //check if the quantity is not <= 0
                if (stock.Quantity <= 0)
                {
                    return new ResponseDTO<StockDTO>
                    {
                        Status = false,
                        Message = "Product quantity should atleast be 1",
                    };
                }
                //check if active stock with same product exist.. return if it already exists
                if (stock.Id == 0)
                {
                    var existingStockWithProduct = await _uowStock.Repository.GetALL(existingItem => existingItem.ProductId == stock.ProductId && existingItem.VendorId==stock.VendorId &&
                    existingItem.Batch==stock.Batch
                    &&  existingItem.IsActive == true).FirstOrDefaultAsync();
                    if (existingStockWithProduct != null)
                    {
                        return new ResponseDTO<StockDTO>
                        {
                            Status = false,
                            Message = "Stock with this product already exist, Please update the product",
                        };
                    }
                }
                

                //this is to update the existing stock 
                var existingStock = await _uowStock.Repository.GetById(stock.Id);
                if (existingStock == null)
                {
                    var newStock = _mapper.Map<Stock>(stock);
                    newStock.CreatedAt = DateTime.Now;
                    newStock.IsActive = true;
                    newStock.CreatedBy = _userDataService.GetUserId();
                    newStock.InStock = true;
                    await _uowStock.Repository.InsertAsync(newStock);
                    await _uowStock.SaveAsync();
                    var stockObj = _mapper.Map<StockDTO>(newStock);

                    return new ResponseDTO<StockDTO>
                    {
                        Status = true,
                        Message = "Stock Added",
                        Data = stockObj
                    };
                }
                else
                {
                    var obj = _mapper.Map(stock, existingStock);
                    obj.UpdatedAt = DateTime.Now;
                    obj.UpdatedBy = _userDataService.GetUserId();
                    _uowStock.Repository.Update(obj);
                    await _uowStock.SaveAsync();
                    var stockObj = _mapper.Map<StockDTO>(obj);
                    return new ResponseDTO<StockDTO>
                    {
                        Status = true,
                        Message = "Stock Updated",
                        Data = stockObj
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ResponseDTO<List<StockDTO>>> GetAll()
        {
            try
            {
                var stock = await _uowStock.Repository.GetALL(x => x.IsActive == true && x.InStock==true).OrderBy(x=>x.CreatedAt).ToListAsync();
                var obj = _mapper.Map<List<StockDTO>>(stock);
                return new ResponseDTO<List<StockDTO>> { Status = true, Message ="Stock record fetched", Data = obj };
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<ResponseDTO<List<StockWithNamesDto>>> GetStockWithNames()
        {
            try
            {
                var conn =
                new SqlConnection(_uowStock.GetDbContext().Database.GetConnectionString());
                conn.Open();
                var result = conn.Query<StockWithNamesDto>(
                    "StockListWithNames",
                    commandType: CommandType.StoredProcedure
                ).OrderByDescending(x => x.CreatedAt).ToList();
                //var stock = await _uowStock.Repository.GetALL(x => x.IsActive == true && x.InStock == true).ToListAsync();
                var obj = _mapper.Map<List<StockWithNamesDto>>(result);
                return new ResponseDTO<List<StockWithNamesDto>> { Status = true, Message = "Stock record fetched", Data = obj };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseDTO<List<StockForUserDTO>>> GetAllStockForTheUser()
        {
            try
            {
                var conn =
                new SqlConnection(_uowStock.GetDbContext().Database.GetConnectionString());
                conn.Open();
                var result = conn.Query<StockForUserDTO>(
                    "StockListForTheUser",
                    commandType: CommandType.StoredProcedure
                ).ToList();
                //var stock = await _uowStock.Repository.GetALL(x => x.IsActive == true && x.InStock == true).ToListAsync();
                var obj = _mapper.Map<List<StockForUserDTO>>(result);
                return new ResponseDTO<List<StockForUserDTO>> { Status = true, Message = "Stock record fetched", Data = obj };
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<StockDTO> GetById(int StockId)
        {
            try
            {
                var stock = await _uowStock.Repository.GetALL(x => x.IsActive == true && x.Id == StockId).FirstOrDefaultAsync();
                var obj = _mapper.Map<StockDTO>(stock);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int StockId)
        {
            try
            {
                var stock = await _uowStock.Repository.GetById(StockId);
                if (stock != null)
                {
                    stock.IsActive = false;
                    await _uowStock.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
