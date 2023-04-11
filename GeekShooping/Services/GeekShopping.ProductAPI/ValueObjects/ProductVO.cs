namespace GeekShopping.ProductAPI.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
