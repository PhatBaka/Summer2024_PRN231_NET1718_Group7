﻿using AutoMapper;
using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.DAL.Models;
using JewelryShop.DTO;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Account;
using JewelryShop.DTO.DTOs.Guarantee;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.DTOs.Material.Metal;
using JewelryShop.DTO.Enums;

namespace JewelryShop.BusinessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(des => des.Role, src => src.MapFrom(src => EnumMapper<RoleEnum>.MapType(src.Role)))
                .ReverseMap(); 
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Guarantee, GuaranteeDTO>().ReverseMap();
            CreateMap<Guarantee, GuaranteeResponse>().ReverseMap();
            /*CreateMap<JewelryMaterial, JewelryMaterialDTO>()
                .ForMember(x => x.Material, dest => dest.MapFrom(dest => dest.Material))
                .ReverseMap();*/
            //CreateMap<JewelryMaterial, JewelryMaterialDTO>()
                //.ForMember(x => x.Material, dest => dest.MapFrom(dest => dest.Material))
                //.ReverseMap();
            //CreateMap<JewelryType, JewelryTypeDTO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
            //CreateMap<MaterialPrice, MaterialPriceDTO>().ReverseMap();
            CreateMap<Offer, OfferDTO>().ReverseMap();
            //CreateMap<Order, OrderDTO>().ReverseMap();
            //CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDiscount, OrderDiscountDTO>().ReverseMap();
            //CreateMap<OrderType, OrderTypeDTO>().ReverseMap();
            //CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<StoreDiscount, StoreDiscountDTO>().ReverseMap();
            CreateMap<Tier, TierDTO>().ReverseMap();

            #region Jewelry
            CreateMap<Jewelry, JewelryDTO>()
                //.ForMember(x => x.TypeName, opt => opt.MapFrom(dest => dest.JewelryTypeNavigation.TypeName))
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

            #region Order
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(dest => dest.Customer.PhoneNumber))
                .ReverseMap();
            CreateMap<OrderDTO, CreateOrderDTO>().ReverseMap();
            #endregion

            #region OrderDetail
            CreateMap<OrderDetail,  OrderDetailDTO>()
                .ForMember(x => x.Jewelry, opt => opt.MapFrom(dest => dest.Jewelry))
                //.ForMember(x => x.ImageId, opt => opt.MapFrom(dest => dest.Jewelry.ImageId))
                .ReverseMap();
            CreateMap<OrderDetailDTO, CreateOrderDetailDTO>().ReverseMap();
            #endregion

            //CreateMap<MaterialDTO, GemDTO>().ReverseMap();
            //CreateMap<MaterialDTO, MetalDTO>().ReverseMap();

            #region Gem
            CreateMap<Material, CreateGemRequest>().ReverseMap();
            CreateMap<Material, UpdateGemRequest>().ReverseMap();
            CreateMap<Material, GemResponse>().ReverseMap();
            #endregion

            #region Account
            CreateMap<Account, CreateAccountRequest>().ReverseMap();
			CreateMap<Account, UpdateAccountRequest>().ReverseMap();
			CreateMap<Account, AccountResponse>().ReverseMap();
            #endregion

            #region Metal
            CreateMap<Material, CreateMetalRequest>().ReverseMap();
            CreateMap<Material, UpdateMetalRequest>().ReverseMap();
            CreateMap<Material, MetalResponse>().ReverseMap();
            #endregion

            #region Jewelry
            CreateMap<Jewelry, CreateJewelryRequest>().ReverseMap();
            CreateMap<Jewelry, UpdateJewelryRequest>().ReverseMap();
            CreateMap<Jewelry, JewelryResponse>().ReverseMap();
            CreateMap<Jewelry, ShortenJewelryResponse>().ReverseMap();
            #endregion

            CreateMap<Material, ShortenMaterialResponse>().ReverseMap();
        }
    }
}
