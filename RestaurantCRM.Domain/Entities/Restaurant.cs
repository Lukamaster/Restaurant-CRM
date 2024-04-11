using System.ComponentModel.DataAnnotations;

namespace RestaurantCRM.Domain.Entities
{
    public class Restaurant : BaseEntity
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<MenuItem>? MenuItems { get; set; }
    }
}
