using RestaurantCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Repository.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetAllOrdersFromRestaurant(Guid RestaurantId);
        IEnumerable<Order> GetActiveOrdersFromRestaurant(Guid restaurantId);
    }
}
