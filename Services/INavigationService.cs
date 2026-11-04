using TodoExplorer.Models;
using TodoExplorer.ViewModels;

namespace TodoExplorer.Services;

public interface INavigationService
{
    void SetNavigation(INavigation navigation);
    Task PopAsync();
    Task GoToTaskDetailAsync(Todo todo);
    Task GoToFavorites(IFavoritesPageViewModel
        favoritesViewModel);
}