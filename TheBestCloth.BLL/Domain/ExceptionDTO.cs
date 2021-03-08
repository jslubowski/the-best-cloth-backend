namespace TheBestCloth.BLL.Domain
{
    public class ExceptionDTO
    {
        public string Message { get; }
        public ExceptionDTO(string message)
        {
            Message = message;
        }
    }
}
