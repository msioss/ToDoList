using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Configurations;
using ToDoList.Data.Entities;

namespace ToDoList.Data.EFContext
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public virtual DbSet<ToDoTask> Tasks { get; set; }
        public virtual DbSet<TaskBlock> TasksBlocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ToDoTaskConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoTaskConfiguration());
        }
    }
}
