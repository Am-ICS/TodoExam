using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoExplorer.Models;
using TodoExplorer.Services;

namespace TodoExplorer.ViewModels;

public partial class ViewModelMainPage : ObservableObject, IViewModelMainPage
{
    private IFavoritesStorage _favoritesStorage;
    private ITodoService _service;
    [ObservableProperty] private ObservableCollection<Todo> todos = new();
    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string errorMessage = "";

    [ObservableProperty]
    private string searchText = "";

    [ObservableProperty]
    private string completionFilter = "All";
    [ObservableProperty]
    private bool isVisible = false;
    
    private List<Todo> alltodos = new();


    public ViewModelMainPage(IFavoritesStorage favoritesStorage, ITodoService service)
    {
        _favoritesStorage = favoritesStorage;
        _service = service;

    }

    public async Task LoadTodoAsync()
    {
        if (IsLoading == true)
        {
            return;
        }
        try
        {

            IsLoading = true;
            ErrorMessage = "";
            dynamic response = await this._service.GetTodos();
            alltodos = response.todos.ToObject<List<Todo>>();


            Todos = new ObservableCollection<Todo>(alltodos);
        }
        catch
        {
            ErrorMessage = "Failed to load todos.";
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void Search()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            Todos = new ObservableCollection<Todo>(alltodos);
            return;
        }

        var filteredTodos = alltodos.Where(todo => todo.todo.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
        Todos = new ObservableCollection<Todo>(filteredTodos);
    }
    
    [RelayCommand]
    private void FilterByCompletion()
    {
        
    }

    [RelayCommand]
    private void ToggleFilter()
    {
        IsVisible = !IsVisible;
    }


}