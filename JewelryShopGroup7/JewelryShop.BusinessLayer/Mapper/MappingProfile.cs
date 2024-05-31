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
            CreateMap<Account, AccountDTO>()
                .ForMember(x => x.Role1, opt => opt.MapFrom(dest => dest.Role.Role1))
                .ReverseMap(); ;
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Guarantee, GuaranteeDTO>().ReverseMap();
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

            #region Jewelry
            CreateMap<Jewelry, JewelryDTO>()
                .ForMember(x => x.TypeName, opt => opt.MapFrom(dest => dest.JewelryTypeNavigation.TypeName))
                //.ForMember(x => x.ImageData, opt => opt.MapFrom(dest => dest.Image.ImageData))
                .ReverseMap();
			CreateMap<JewelryDTO, CreateJewelryDTO>().ReverseMap();
            CreateMap<JewelryDTO, UpdateJewelryDTO>().ReverseMap();
            #endregion

            #region Image
            CreateMap<Image, ImageDTO>().ReverseMap();
			CreateMap<ImageDTO, CreateImageDTO>().ReverseMap();
            CreateMap<ImageDTO, UpdateImageDTO>().ReverseMap();
            #endregion
        }
    }
}
