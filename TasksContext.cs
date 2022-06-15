namespace projectef
{
    using Microsoft.EntityFrameworkCore;
    using projectef.Models;

    public class TasksContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) :base(options) {}
    }
}