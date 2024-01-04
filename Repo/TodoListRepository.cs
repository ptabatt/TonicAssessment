using Microsoft.EntityFrameworkCore;
using TonicTodoList.Console.Repo;

public class TodoListRepository : IRepository<TodoItem>
{
    public TodoItem GetById(int id)
    {
        using (var dbContext = new TodoDbContext())
        {
            return dbContext.TodoItems.FirstOrDefault(item => item.Id == id);
        }
    }

    public void Add(TodoItem entity)
    {
        using (var dbContext = new TodoDbContext())
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            dbContext.TodoItems.Add(entity);
            dbContext.SaveChanges();
        }
    }

    public IEnumerable<TodoItem> GetAll()
    {
        using (var dbContext = new TodoDbContext())
        {
            return dbContext.TodoItems.OrderBy(x => x.CreatedAt).ToList();
        }
    }

    public TodoItem GetNthItem(int n)
    {
        using (var dbContext = new TodoDbContext())
        {
            return dbContext.TodoItems.OrderBy(item => item.CreatedAt).Skip(n - 1).FirstOrDefault();
        }
    }

    public void Update(TodoItem entity)
    {
        using (var dbContext = new TodoDbContext())
        {
            dbContext.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }

    public void DeleteAll()
    {
        using (var dbContext = new TodoDbContext())
        {
            var allItems = dbContext.TodoItems.ToList();
            dbContext.TodoItems.RemoveRange(allItems);
            dbContext.SaveChanges();
        }
    }

    public int Count()
    {
        using (var dbContext = new TodoDbContext())
        {
            return dbContext.TodoItems.Count();
        }
    }
}
