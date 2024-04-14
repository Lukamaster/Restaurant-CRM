using RestaurantCRM.Domain.Entities;
using RestaurantCRM.Repository.Interface;
using RestaurantCRM.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Create(order);
        }

        public void DeleteOrder(Guid Id)
        {
            _orderRepository.Delete(GetOrderById(Id));
        }

        public List<Order> GetActiveOrdersFromRestaurant(Guid restaurantId)
        {
            return _orderRepository.GetActiveOrdersFromRestaurant(restaurantId).ToList();
        }

        public List<Order> GetAllOrdersFromRestaurant(Guid restaurantId)
        {
            return _orderRepository.GetAllOrdersFromRestaurant(restaurantId).ToList();
        }

        public Order GetOrderById(Guid Id)
        {
            return _orderRepository.GetById(Id);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }

        public void UpdateOrderStatus(Order order, OrderStatus orderStatus)
        {
            Order order_to_update = _orderRepository.GetById(order.Id);
            order_to_update.Status = orderStatus;
            _orderRepository.Update(order_to_update);
        }
    }
}
