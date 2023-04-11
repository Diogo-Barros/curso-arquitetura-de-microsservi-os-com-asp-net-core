namespace GeekShopping.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; } = new CartHeaderViewModel();
        public IEnumerable<CartDetailViewModel> CartDetails { get; set; } = new List<CartDetailViewModel>();
    }
}
