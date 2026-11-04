using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using TodoExplorer.Models;
using TodoExplorer.Services;

namespace TodoExplorer.ViewModels;

public partial class FavoritesPageViewModel: ObservableObject, IFavoritesPageViewModel
{
    [ObservableProperty] private ObservableCollection<Todo> favoriteTodos = new();
    private readonly IFavoritesStorage  _favoritesStorage;
    private readonly ITodoService  _todoService;

    public FavoritesPageViewModel(IFavoritesStorage favoritesStorage, ITodoService todoService)
    {
        _favoritesStorage = favoritesStorage;
        _todoService = todoService;
    }
    public async Task LoadFavoriteTodos()
    {
        List<int> favorsitesIds = await _favoritesStorage.LoadFavorites();
        dynamic response = await _todoService.GetTodos();
        List<Todo> allTodosfavorsite = response.todos.ToObject<List<Todo>>();
        favoriteTodos.Clear();
        foreach (int id in favorsitesIds)
        {
            Todo? favoriteTodo = allTodosfavorsite.FirstOrDefault(t => t.Id == id);
            if (favoriteTodo != null)
            {
                favoriteTodos.Add(favoriteTodo);
            }
        }
    }
}