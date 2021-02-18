using System.Text.Json.Serialization;

namespace TheBestCloth.BLL.ModelDatabase
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string PublicId { get; set; }
        [JsonIgnore]
        public ShoppingItem ShoppingItem { get; set; }
    }
}
