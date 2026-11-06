using TodoExplorer.Models;
using TodoExplorer.ViewModels;
using TodoExplorer.Views;

namespace TodoExplorer.Services;

public class NavigationService : INavigationService
{
    private INavigation _navigation;
    public void SetNavigation(INavigation navigation)
    {
        this._navigation = navigation;
    }

    public async Task PopAsync()
    {
        await this._navigation.PopAsync();
    }

    public async Task GoToTaskDetailAsync(Todo todo)
    {
        await _navigation.PushAsync(new TodoDetailsPage(todo));
    }

    public async Task GoToFavorites(IFavoritesPageViewModel favoritesViewModel)
    {
        await this._navigation.PushAsync(new FavoritesPage(favoritesViewModel));
    }
}