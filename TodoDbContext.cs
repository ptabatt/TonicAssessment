using Microsoft.EntityFrameworkCore;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todos.db");
        base.OnConfiguring(optionsBuilder);
    }
}
