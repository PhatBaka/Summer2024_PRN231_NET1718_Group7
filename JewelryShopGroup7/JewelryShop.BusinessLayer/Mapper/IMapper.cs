namespace JewelryShop.BusinessLayer.Mapper;

public interface IMapper<TSource, TDestination>
{
    TDestination Map(TSource source);
}
