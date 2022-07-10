namespace ToDoList.Data.Entities
{
    public class TaskBlock
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ToDoTask> Tasks { get; set; }
    }
}
