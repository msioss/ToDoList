namespace ToDoList.Data.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public int TaskBlockId { get; set; }
        public virtual TaskBlock TaskBlocks { get; set; }
    }
}
