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
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository<MenuItem> _repository;

        public MenuItemService(IRepository<MenuItem> repository)
        {
            _repository = repository;
        }
        public void Create(MenuItem menuItem)
        {
            _repository.Create(menuItem);
        }

        public void Delete(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public MenuItem GetMenuItemById(Guid id)
        {
            return _repository.GetById(id);
        }

        public List<MenuItem> GetMenuItems(Guid? id)
        {
            return _repository.GetAll().Where(z => z.RestaurantId == id).ToList();
        }

        public void Update(MenuItem menuItem)
        {
            _repository.Update(menuItem);
        }
    }
}
