using TonicTodoList.Console.Repo;

using (var db = new TodoDbContext())
{
    db.Database.EnsureCreated();
}

var repo = new TodoListRepository();

while (true)
{
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. Mark task as completed or not completed");
    Console.WriteLine("3. Display all tasks");
    Console.WriteLine("4. Delete all tasks");
    Console.WriteLine("5. Exit");

    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                Console.Write("Enter the task: ");
                string task = Console.ReadLine();

                var newItem = new TodoItem
                {
                    Task = task,
                    IsCompleted = false,
                    CreatedAt = DateTime.Now
                };

                repo.Add(newItem);

                DisplayTasks(repo);

                break;
            }

        case "2":
            {
                Console.Write("Enter the task number: ");

                var input = Console.ReadLine();

                if (int.TryParse(input, out int taskNum) && taskNum > 0)
                {
                    var task = repo.GetNthItem(taskNum);

                    if (task != null)
                    {
                        task.IsCompleted = !task.IsCompleted;
                        repo.Update(task);

                        DisplayTasks(repo);

                        break;
                    }
                }

                Console.Write($"Invalid selection: {input} \n");

                break;
            }

        case "3":
            DisplayTasks(repo);
            break;

        case "4":
            {
                Console.Write("Are you sure? Press y to confirm, and anything else to cancel. \n");

                var input = Console.ReadLine();

                if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase))
                {
                    repo.DeleteAll();
                }

                break;
            }

        case "5":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

static void DisplayTasks(IRepository<TodoItem> repo)
{
    Console.WriteLine("Todo List:");
    var items = repo.GetAll();

    var taskNumber = 0;
    foreach (var item in items)
    {
        Console.WriteLine($"    {++taskNumber}. {(item.IsCompleted ? "[X]" : "[ ]")} {item.Task} "
            + $" (Created: {item.CreatedAt})");
    }
}