using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Service
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }


        public async Task DeleteBasketAsync(string userID)
        {
           var status = await _redisService.GetDb().KeyDeleteAsync(userID);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userID)
        {
            var  existBasket = await _redisService.GetDb().StringGetAsync(userID);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task  SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
