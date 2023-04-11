﻿using GeekShooping.CartAPI.ValueObjects;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShooping.CartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly HttpClient _httpClient;

        public CouponRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public const string BasePath = "api/v1/coupon";

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            if ( response.StatusCode != HttpStatusCode.OK) 
            {
                return new CouponVO();
            }
            return JsonSerializer.Deserialize<CouponVO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
