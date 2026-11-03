using CommunityToolkit.Mvvm.Input;

namespace TodoExplorer.ViewModels;

public interface IViewModelMainPage
{
    IRelayCommand ToggleFilterCommand { get; }
    IRelayCommand SearchCommand { get; }
    Task LoadTodoAsync();
}