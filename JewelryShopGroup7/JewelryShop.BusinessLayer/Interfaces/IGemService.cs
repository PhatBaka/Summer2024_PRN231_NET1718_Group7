using JewelryShop.DTO.DTOs.Material.Gem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IGemService : IService<GemResponse, CreateGemRequest, UpdateGemRequest, GemFilter>
    {
    }
}
