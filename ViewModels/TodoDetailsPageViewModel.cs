using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using TodoExplorer.Models;

namespace TodoExplorer.ViewModels;

public partial class TodoDetailsPageViewModel: ObservableObject
{
    [ObservableProperty]
    
    private Todo? selectedTodo;

    public TodoDetailsPageViewModel(Todo todo)
    {
        SelectedTodo = todo;
    }
}