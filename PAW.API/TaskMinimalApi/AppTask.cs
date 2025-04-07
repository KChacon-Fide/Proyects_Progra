using Microsoft.EntityFrameworkCore;

namespace TaskMinimalApi;

public class AppTask
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool IsCompleted { get; set; }
}

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<AppTask> Tasks { get; set; }
}
