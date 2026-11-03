namespace TodoExplorer.Models;


public class Todo
{
    public int Id { get; set; }
    public string todo { get; set; }
    public int userId { get; set; }
    public bool IsCompleted { get; set; }
}