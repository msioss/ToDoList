using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Configurations
{
    public class TaskBlockConfiguration : IEntityTypeConfiguration<TaskBlock>
    {
        public void Configure(EntityTypeBuilder<TaskBlock> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(e => e.Tasks)
                .WithOne(e => e.TasksBlock);
        }

    }
}
