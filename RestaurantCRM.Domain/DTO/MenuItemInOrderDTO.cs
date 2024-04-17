using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Domain.DTO
{
    public class MenuItemInOrderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
