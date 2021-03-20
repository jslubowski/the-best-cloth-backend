namespace TheBestCloth.BLL.Domain
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
