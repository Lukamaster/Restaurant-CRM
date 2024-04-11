using RestaurantCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid? id);
        T GetByName(string name);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
