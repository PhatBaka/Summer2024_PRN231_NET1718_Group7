using AutoMapper;
using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.DAL.Models;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Account;
using JewelryShop.DTO.DTOs.Customer;
using JewelryShop.DTO.DTOs.Guarantee;
using JewelryShop.DTO.DTOs.Image;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.JewelryMaterial;
using JewelryShop.DTO.DTOs.Material;
using JewelryShop.DTO.DTOs.Offer;
using JewelryShop.DTO.DTOs.Order;
using JewelryShop.DTO.DTOs.OrderDetail;
using JewelryShop.DTO.DTOs.OrderDiscount;
using JewelryShop.DTO.DTOs.StoreDiscount;
using JewelryShop.DTO.DTOs.Tier;
using JewelryShop.DTO.Enums;

namespace JewelryShop.BusinessLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region account
            CreateMap<Account, AccountResponse>()
                    .ForMember(des => des.Role, src => src.MapFrom(src => EnumMapper<RoleEnum>.MapType(src.Role)));
            CreateMap<CreateAccountRequest, Account>();
            CreateMap<UpdateAccountRequest, Account>(); 
            #endregion

            #region customer
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>(); 
            #endregion

            #region Guarantee
            CreateMap<Guarantee, GuaranteeResponse>();
            CreateMap<CreateGuaranteeRequest, Guarantee>();
            CreateMap<UpdateGuaranteeRequest, Guarantee>(); 
            #endregion

            #region image
            CreateMap<Image, ImageResponse>();
            CreateMap<CreateImageRequest, Image>();
            CreateMap<UpdateImageRequest, Image>(); 
            #endregion

            #region Jewelry
            CreateMap<Jewelry, JewelryResponse>();
                //.ForMember(x => x.TypeName, opt => opt.MapFrom(dest => dest.JewelryTypeNavigation.TypeName))
                //.ForMember(x => x.ImageData, opt => opt.MapFrom(dest => dest.Image.ImageData))
            CreateMap<UpdateJewelryRequest, Jewelry>();
            CreateMap<CreateJewelryRequest, Jewelry>();
            #endregion

            #region JewelryMaterial
            CreateMap<JewelryMaterial, JewelryMaterialResponse>()
                   .ForMember(x => x.Material, dest => dest.MapFrom(dest => dest.Material))
                   .ReverseMap();
            CreateMap<CreateJewelryMaterialRequest, JewelryMaterial>();
            CreateMap<UpdateJewelryMaterialRequest, JewelryMaterial>(); 
            #endregion


            #region Material
            CreateMap<Material, MaterialResponse>();
            CreateMap<CreateMaterialRequest, Material>();
            CreateMap<UpdateMaterialRequest, Material>(); 
            #endregion

            #region Offer
            CreateMap<Offer, OfferResponse>();
            CreateMap<CreateOfferRequest, Offer>();
            CreateMap<UpdateOffterRequest, Offer>(); 
            #endregion

            #region Order
            CreateMap<Order, OrderResponse>()
               // .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(dest => dest.Customer.PhoneNumber))
                .ReverseMap();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();
            #endregion

            #region OrderDetail
            CreateMap<OrderDetail, OrderDetailResponse>()
                .ForMember(x => x.Jewelry, opt => opt.MapFrom(dest => dest.Jewelry))
                .ForMember(x => x.ImageId, opt => opt.MapFrom(dest => dest.Jewelry.ImageId))
                .ReverseMap();
            CreateMap<CreateOrderDetailRequest, OrderDetail>();
            CreateMap<UpdateOrderDetailRequest, OrderDetail>();
            #endregion

            #region order discount
            CreateMap<OrderDiscount, OrderDiscountResponse>();
            CreateMap<CreateOrderDiscountRequest, OrderDiscount>();
            CreateMap<UpdateOrderDiscountRequest, OrderDiscount>();
            #endregion

            #region store discount
            CreateMap<StoreDiscount, StoreDiscountResponse>();
            CreateMap<CreateStoreDiscountRequest, StoreDiscount>();
            CreateMap<UpdateStoreDiscountRequest, StoreDiscount>();
            #endregion

            #region tier
            CreateMap<Tier, TierResponse>();
            CreateMap<CreateTierRequest, Tier>();
            CreateMap<UpdateTierRequest, Tier>(); 
            #endregion

        }
    }
}
