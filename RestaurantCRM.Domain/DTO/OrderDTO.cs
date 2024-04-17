using RestaurantCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Domain.DTO
{
    public class OrderDTO
    {
        public int tableNumber { get; set; } 
        public Guid RestaurantId { get; set; }
        public ICollection<MenuItemInOrderDTO> MenuItems { get; set; }
    }
}
