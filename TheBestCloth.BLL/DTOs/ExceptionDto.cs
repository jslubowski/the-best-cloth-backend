namespace TheBestCloth.BLL.DTOs
{
    public class ExceptionDto
    {
        public string Message { get; }
        public ExceptionDto(string message)
        {
            Message = message;
        }
    }
}
