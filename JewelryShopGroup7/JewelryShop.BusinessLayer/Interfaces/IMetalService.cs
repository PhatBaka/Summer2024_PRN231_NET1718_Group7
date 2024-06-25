using JewelryShop.DTO.DTOs.Material.Metal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IMetalService : IService<MetalResponse, CreateMetalRequest, UpdateMetalRequest, MetalFilter>
    {
    }
}
