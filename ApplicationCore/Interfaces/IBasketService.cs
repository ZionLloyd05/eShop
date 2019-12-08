using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task<int> GetBasketItemCountAsync(string userName);
        Task TransferBasketAsync(string anonymousId, string userName);
        Task AddItemToBasket(int basketId, int catatlogItemId, decimal price, int quantity);
        Task SetQuantities(int basketId, Dictionary<string, int> quantity);
        Task DeleteBasketAsync(int basketId);
    }
}
