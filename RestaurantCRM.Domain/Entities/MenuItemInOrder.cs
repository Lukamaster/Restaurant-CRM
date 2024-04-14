using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Domain.Entities
{
    public class MenuItemInOrder : BaseEntity
    {
        public Guid MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
        public Guid RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public int Quantity { get; set; }
    }
}
