namespace TheBestCloth.BLL.ModelDatabase
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public ShoppingItem ShoppingItem { get; set; }
    }
}
