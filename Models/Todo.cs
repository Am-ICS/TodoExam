using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoExplorer.Models;


public partial class Todo : ObservableObject
{
    public int Id { get; set; }
    public string todo { get; set; }
    public int userId { get; set; }
    public bool completed { get; set; }
    [ObservableProperty] private bool isFavorite;
}