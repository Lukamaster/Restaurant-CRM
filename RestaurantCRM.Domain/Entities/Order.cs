using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public int TableNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public virtual ICollection<MenuItemInOrder> ItemsOrdered { get; set; }

        public Order(string Name, int TableNumber, ICollection<MenuItemInOrder> ItemsOrdered)
        {
            this.Name = Name;
            this.TableNumber = TableNumber;
            this.ItemsOrdered = ItemsOrdered;
            this.OrderDate = DateTime.Now;
            this.Status = OrderStatus.Waiting;
        }
        public Order()
        {
            this.OrderDate = DateTime.Now;
            this.Status = OrderStatus.Waiting;
        }
    }
}
