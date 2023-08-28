using Assesment_28aug.Dbcontext;
using Assesment_28aug.Models;

namespace Assesment_28aug.Repos
{
    public class OrderRepository
    {
        private OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }
         public List<Order> GetAllOrder(int userId)
         {
            return _context.Orders.Where(x => x.UserId == userId).ToList();

            
         }
        public Order PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

    }
}
