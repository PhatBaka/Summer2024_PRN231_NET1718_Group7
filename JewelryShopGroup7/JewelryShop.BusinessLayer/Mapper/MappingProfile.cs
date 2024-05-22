using AutoMapper;
using JewelryShop.DAL.Models;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Guarantee, GuaranteeDTO>().ReverseMap();
            CreateMap<Jewelry, JewelryDTO>().ReverseMap();
            CreateMap<JewelryMaterial, JewelryMaterialDTO>().ReverseMap();
            CreateMap<JewelryType, JewelryTypeDTO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<MaterialPrice, MaterialPriceDTO>().ReverseMap();
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDiscount, OrderDiscountDTO>().ReverseMap();
            CreateMap<OrderType, OrderTypeDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<StoreDiscount, StoreDiscountDTO>().ReverseMap();
            CreateMap<Tier, TierDTO>().ReverseMap();
        }
    }
}
