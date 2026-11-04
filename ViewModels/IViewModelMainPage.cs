using CommunityToolkit.Mvvm.Input;
using TodoExplorer.Models;

namespace TodoExplorer.ViewModels;

public interface IViewModelMainPage 
{
    IRelayCommand ToggleFilterCommand { get; }
    IRelayCommand SearchCommand { get; }
    IAsyncRelayCommand<Todo> FavoriteCommand { get; }    
    Task LoadTodoAsync();
    IRelayCommand<Todo> SelectedTodoCommand { get; }
}