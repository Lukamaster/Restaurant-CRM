using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantCRM.Domain.DTO
{
    public class MenuItemDTO
    {
        public string Name { get; set; }
        public string ListOfIngredients { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
