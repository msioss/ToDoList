using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Configurations
{
    public class TasksBlockConfiguration : IEntityTypeConfiguration<TasksBlock>
    {
        public void Configure(EntityTypeBuilder<TasksBlock> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(e => e.Tasks)
                .WithOne(e => e.TasksBlock);
        }

    }
}
