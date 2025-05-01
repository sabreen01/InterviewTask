using l.applicaion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l.applicaion.IServices
{
    public interface IWareHouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllAsync();
        Task<bool> CreateAsync(WarehouseDto stockDto);
    }
}
