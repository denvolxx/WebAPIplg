namespace WebAPIplg.Models
{
    public class ServiceResponce<T>
    {
        public T? Value { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
