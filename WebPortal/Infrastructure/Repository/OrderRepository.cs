using WebPortal.Database;
using WebPortal.Infrastructure.Irepository;
using WebPortal.Models;

namespace WebPortal.Infrastructure.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly DataCtxt _dbCntxt;

        public OrderRepository(DataCtxt dbCntxt)
        {
            _dbCntxt = dbCntxt;
        }


        Task<bool> IOrder.createAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Order>> IOrder.GetAllAsync()
        {
            throw new NotImplementedException();
        }

      async  Task<Order> IOrder.GetAsync(int id)
        {
            var order = await _dbCntxt.orders.FindAsync(id);

            return order;
            
        }


        async Task<bool> IOrder.UpdateAsync(int id, Order order)
        {
            var data = await _dbCntxt.orders.FindAsync(id);

            if (data != null)
            {
                _dbCntxt.orders.Attach(data);

                data.Status = order.Status;

                



                return true;
            }
            return false;
        }
    }
}
