namespace ToDoList.Models
{
    public class ServiceResponceModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Responce { get; set; }
        public string Error { get; set; }
    }
}
