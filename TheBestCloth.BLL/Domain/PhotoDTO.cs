namespace TheBestCloth.BLL.Domain
{
    public class PhotoDto
    {
        public string PhotoUrl { get; set; }
        public string PublicId { get; set; }
        public PhotoDto(string photoUrl, string publicId)
        {
            PhotoUrl = photoUrl;
            PublicId = publicId;
        }
    }
}
