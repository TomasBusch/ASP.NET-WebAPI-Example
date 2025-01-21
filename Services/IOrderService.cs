using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IOrderService
    {
        public void MakeOrder(Cart cart);
    }
}
