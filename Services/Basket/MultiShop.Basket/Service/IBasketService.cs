using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Service
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string userID);
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userID);

    }
}
