using GeekShooping.CartAPI.Messages;
using GeekShooping.CartAPI.RabbitMQSender;
using GeekShooping.CartAPI.Repository;
using GeekShooping.CartAPI.ValueObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        
        private readonly IRabbitMQMessageSender _messageSender;

        public CartController(ICartRepository cartRepository, IRabbitMQMessageSender messageSender, ICouponRepository couponRepository)
        {
            _cartRepository = cartRepository;
            _messageSender = messageSender;
            _couponRepository = couponRepository;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindById(string id)
        {
            var cart = await _cartRepository.FindCartByUserId(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart == null)
            { 
                return NotFound(); 
            }
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO vo)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(vo);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status)
            {
                return BadRequest();
            }
            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartVO>> ApplyCoupon(CartVO vo)
        {
            var status = await _cartRepository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            if (status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartVO>> ApplyCoupon(string userId)
        {
            var status = await _cartRepository.RemoveCoupon(userId);
            if (status == false)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            //string token = Request.Headers["Authorization"];
            string token = await HttpContext.GetTokenAsync("access_token");
            if (vo?.UserId == null)
            {
                return BadRequest();
            }

            var cart = await _cartRepository.FindCartByUserId(vo.UserId);
            
            if (cart == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(vo.CouponCode))
            {
                CouponVO coupon = await _couponRepository.GetCouponByCouponCode(vo.CouponCode, token);
                if (vo.DiscountAmount != coupon.DiscountAmount)
                {
                    return StatusCode(412);
                }
            }

            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.UtcNow;

            _messageSender.SendMessage(vo, "checkoutqueue");

            await _cartRepository.ClearCart(vo.UserId);

            return Ok (vo);
        }
    }
}
