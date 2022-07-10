using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Configurations
{
    public class ToDoTaskConfiguration: IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.TasksBlock)
                .WithMany(e => e.Tasks)
                .HasForeignKey(e => e.TasksBlockId)
                .IsRequired();
        }
    }
}
