namespace JewelryStoreUI.Pages.Helpers
{
    public class ResponseResult<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool? Result { get; set; }
    }
}
