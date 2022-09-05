namespace projectef;

using Microsoft.EntityFrameworkCore;
using projectef.Models;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            category.Property(c => c.Description);

        });

        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);
            task.HasOne(t => t.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(t => t.CategoryId);
            task.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);
            task.Property(t => t.Description);
            task.Property(t => t.PriorityTask);
            task.Property(t => t.CreationDate);
            task.Ignore(t => t.Summary);
        });
    }
}
