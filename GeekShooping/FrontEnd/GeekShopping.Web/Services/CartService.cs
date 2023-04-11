using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private const string BasePath = "api/v1/cart";
        private const string Bearer = "Bearer";

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            var reponse = await _httpClient.GetAsync($"{BasePath}/find-cart/{userId}");
            return await reponse.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            var response = await _httpClient.PostAsJson($"{BasePath}/add-cart", cart);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CartViewModel>();
            }
            throw new Exception("Something went wrong when calling API.");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            var response = await _httpClient.PutAsJson($"{BasePath}/update-cart", cart);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CartViewModel>();
            }
            throw new Exception("Something went wrong when calling API.");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<bool>();
            }
            throw new Exception("Something went wrong when calling API.");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            var response = await _httpClient.PostAsJson($"{BasePath}/apply-coupon", cart);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<bool>();
            }
            throw new Exception("Something went wrong when calling API.");
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/remove-coupon/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<bool>();
            }
            throw new Exception("Something went wrong when calling API.");
        }

        public async Task<object> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, token);
            
            var response = await _httpClient.PostAsJson($"{BasePath}/checkout", cartHeader);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CartHeaderViewModel>();
            }
            else if (response.StatusCode.ToString().Equals("PreconditionFailed"))
            {
                return "Coupom price has changed, please confirm!";
            }
            throw new Exception("Something went wrong when calling API.");
        }

        public Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
