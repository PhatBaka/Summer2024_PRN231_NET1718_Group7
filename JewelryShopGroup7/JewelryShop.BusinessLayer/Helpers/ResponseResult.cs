namespace JewelryShop.BusinessLayer.Helpers
{
    public class ResponseResult<T>
    {
        public string? Message { get; set; }
        public T? Data { get; set; }
        public bool? Result { get; set; }
    }
}
