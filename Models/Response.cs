namespace Session2.Models
{
    public class Response
    {
        public string Message { get; }
        public object Data { get; }

        public Response(string message, object data)
        {
            Message = message;
            Data = data;
        }
    }
}
