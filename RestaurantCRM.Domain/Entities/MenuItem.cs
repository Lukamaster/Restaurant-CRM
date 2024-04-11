namespace RestaurantCRM.Domain.Entities
{
    public class MenuItem : BaseEntity
    {
        public string ListOfIngredients { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }
    }
}
