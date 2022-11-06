using WebPortal.Models;

namespace WebPortal.Infrastructure.Irepository
{
    public interface IOrder
    {
        Task<ICollection<Order>> GetAllAsync();


        Task<Order> GetAsync(int id);
        Task<bool> UpdateAsync(int id, Order order);
        Task<bool> createAsync(Order order);
    }
}
