using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoExplorer.Models;
using TodoExplorer.Services;
using ISwipeItem = Microsoft.Maui.ISwipeItem;

namespace TodoExplorer.ViewModels;

public partial class ViewModelMainPage : ObservableObject, IViewModelMainPage 
{
    private IFavoritesStorage _favoritesStorage;
    private ITodoService _service;
    private IFavoritesPageViewModel favoritesViewModel;
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
    private string userIdFilter = "";
    [ObservableProperty]
    private bool isVisible = false;
    
    private List<Todo> alltodos = new();

    private readonly INavigationService _navigationService;

    public ViewModelMainPage(IFavoritesStorage favoritesStorage, ITodoService service, INavigationService navigationService, IFavoritesPageViewModel favoritesViewModel)
    {
        _favoritesStorage = favoritesStorage;
        _service = service;
        _navigationService = navigationService;
        this.favoritesViewModel = favoritesViewModel;

    }

    [RelayCommand]
    private async Task SelectedTodo(Todo todo)
    {
        await _navigationService.GoToTaskDetailAsync(todo);
    }

    [RelayCommand]
    private async Task FavNavNext()
    {
        await _navigationService.GoToFavorites(favoritesViewModel);
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
            
            
            List<int> favoriteIds = await _favoritesStorage.LoadFavorites();
            foreach (Todo todo in alltodos)
            {
                if (favoriteIds.Contains(todo.Id))
                {
                    todo.IsFavorite = true;
                }
            }

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
        IEnumerable<Todo> filteredTodos = alltodos;

        if (!string.IsNullOrWhiteSpace(SearchText))
        { 
            filteredTodos = alltodos.Where(todo => todo.todo.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

        }
        
        if (int.TryParse(UserIdFilter, out int userId))
        {
            filteredTodos = filteredTodos.Where(todo => todo.userId == userId).ToList();
        }

        if (CompletionFilter == "Completed")
        {
            filteredTodos = filteredTodos.Where(todo => todo.completed == true).ToList();
        } 
        else if (CompletionFilter == "Incomplete")
        {
            filteredTodos = filteredTodos.Where(todo => todo.completed == false).ToList();
        }
        Todos = new ObservableCollection<Todo>(filteredTodos.ToList());

    }
    

    [RelayCommand]
    private void ToggleFilter()
    { 
        IsVisible = !IsVisible;
    }

    [RelayCommand]
    private async Task Favorite(Todo todo)
    { 
        todo.IsFavorite = !todo.IsFavorite;

        List<int> favoriteIds = alltodos
            .Where(todo => todo.IsFavorite == true)
            .Select(todo => todo.Id)
            .ToList();
        await _favoritesStorage.SaveFavorites(favoriteIds);
    }


}