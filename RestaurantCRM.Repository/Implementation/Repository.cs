using Microsoft.EntityFrameworkCore;
using RestaurantCRM.Domain.Entities;
using RestaurantCRM.Repository.Interface;

namespace RestaurantCRM.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
            this.entities = applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }


        public void Create(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public T GetById(Guid? id)
        {
            return entities.First(e => e.Id == id);
        }

        public T GetByName(string name)
        {
            return entities.First(e => e.Name == name);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
