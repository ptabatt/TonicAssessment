using System.ComponentModel.DataAnnotations;

public class TodoItem
{
    [Key]
    public int Id { get; set; }
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
}