namespace ToDoList.Data.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public int TasksBlockId { get; set; }
        public virtual TasksBlock TasksBlock { get; set; }
    }
}
