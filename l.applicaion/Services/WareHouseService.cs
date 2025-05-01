using domain.Models;
using infrastructure;
using l.applicaion.DTOs;
using l.applicaion.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l.applicaion.Services
{
    public class WareHouseService: IWareHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WareHouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> CreateAsync(WarehouseDto stockDto)
        {
            var stock = new Warehouse
            {
                Name = stockDto.Name,
                Description = stockDto.Description,
            };

            await _unitOfWork.StockRepository.AddAsync(stock);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var res = await _unitOfWork.StockRepository.GetAllAsync();
            return res.ToList().Select(e => new WarehouseDto { Id = e.Id, Name = e.Name, Description = e.Description }).ToList();
        }

    }
}
