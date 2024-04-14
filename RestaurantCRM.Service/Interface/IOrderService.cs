using RestaurantCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetActiveOrdersFromRestaurant(Guid restaurantId);
        List<Order> GetAllOrdersFromRestaurant(Guid restaurantId);
        Order GetOrderById(Guid Id);
        void DeleteOrder(Guid Id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void UpdateOrderStatus(Order order, OrderStatus orderStatus);

    }
}
