namespace TheBestCloth.BLL.Domain
{
    public class PhotoDTO
    {
        public string PhotoUrl { get; set; }
        public string PublicId { get; set; }
        public PhotoDTO(string photoUrl, string publicId)
        {
            PhotoUrl = photoUrl;
            PublicId = publicId;
        }
    }
}
