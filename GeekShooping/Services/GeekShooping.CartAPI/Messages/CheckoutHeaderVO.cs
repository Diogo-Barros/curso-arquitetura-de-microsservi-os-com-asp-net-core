using GeekShooping.CartAPI.ValueObjects;
using GeekShooping.MessageBus;

namespace GeekShooping.CartAPI.Messages
{
    public class CheckoutHeaderVO : BaseMessage
    {
        public string UserId { get; set; } = string.Empty;
        public string CouponCode { get; set; } = string.Empty;
        public decimal PurchaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string ExpiryMothYear { get; set; } = string.Empty;
        public int CartTotalItens { get; set; } = 0;
        public IEnumerable<CartDetailVO>? CartDetails { get; set; }
    }
}
