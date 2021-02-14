namespace TheBestCloth.API.Models
{
    public class ShoppingItemModel : RestModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
