using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
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

        IsLoading = true;
        ErrorMessage = "";
        dynamic response =  await this._service.GetTodos();
    }

}