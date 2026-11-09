using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using TodoExplorer.Models;
using TodoExplorer.Services;

namespace TodoExplorer.ViewModels;

public partial class FavoritesPageViewModel: ObservableObject, IFavoritesPageViewModel
{
    [ObservableProperty] private ObservableCollection<Todo> favTodos = new();
    private readonly IFavoritesStorage  _favoritesStorage;
    private readonly ITodoService  _todoService;

    public FavoritesPageViewModel(IFavoritesStorage favoritesStorage, ITodoService todoService)
    {
        _favoritesStorage = favoritesStorage;
        _todoService = todoService;
    }
 }

//