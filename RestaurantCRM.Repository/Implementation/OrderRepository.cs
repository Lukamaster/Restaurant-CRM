using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RestaurantCRM.Domain.Entities;
using RestaurantCRM.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
            this.entities = applicationDbContext.Set<Order>();
        }

        public IEnumerable<Order> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<Order> GetAllOrdersFromRestaurant(Guid RestaurantId)
        {
            return entities.Where(x => x.RestaurantId == RestaurantId)
                .AsEnumerable();
        }

        public IEnumerable<Order> GetActiveOrdersFromRestaurant(Guid restaurantId)
        {
            return entities.Where(x => (x.RestaurantId == restaurantId)
            && x.Status == OrderStatus.Waiting
            || x.Status == OrderStatus.Approved)
                .AsEnumerable();
        }

        public void Create(Order entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public Order GetById(Guid? id)
        {
            return entities.First(e => e.Id == id);
        }

        public Order GetByName(string name)
        {
            return entities.First(e => e.Name == name);
        }

        public void Update(Order entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }

}
