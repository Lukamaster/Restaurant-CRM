using RestaurantCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Service.Interface
{
    public interface IMenuItemService
    {
        List<MenuItem> GetMenuItems(Guid? id);
        MenuItem GetMenuItemById(Guid id);
        void Create(MenuItem menuItem);
        void Update(MenuItem menuItem);
        void Delete(MenuItem menuItem);
    }
}
