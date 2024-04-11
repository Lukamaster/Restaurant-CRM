using RestaurantCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Service.Interface
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(Guid? id);
        void AddNew(Restaurant restaurant);
        void Edit(Restaurant restaurant);
        void Delete(Guid? id);
        void AddNewItem(Guid? id, MenuItem item);
    }
}
