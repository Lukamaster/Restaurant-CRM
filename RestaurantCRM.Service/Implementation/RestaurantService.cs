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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _repository;

        public RestaurantService(IRepository<Restaurant> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _repository.GetAll();
        }

        public void AddNew(Restaurant restaurant)
        {
            _repository.Create(restaurant);
        }

        public void AddNewItem(Guid? id, MenuItem item)
        {
            if(id != null)
            {
                var restaurant_to_add = _repository.GetById(id);
                restaurant_to_add.MenuItems.Add(item);
            }

        }

        public void Delete(Guid? id)
        {
            var restaurant_to_delete = _repository.GetById(id);
            _repository.Delete(restaurant_to_delete);
        }

        public void Edit(Restaurant restaurant)
        {
            _repository.Update(restaurant);
        }

        public Restaurant GetById(Guid? id)
        {
            return _repository.GetById(id);
        }
    }
}
