using TodoExplorer.Models;
using TodoExplorer.ViewModels;

namespace TodoExplorer.Services;

public interface INavigationService
{
    void SetNavigation(INavigation navigation);
    Task PopAsync();
    Task GoToTaskDetailAsync(TodoDetailsPageViewModel  viewModel);
    Task GoToFavorites(IFavoritesPageViewModel
        favoritesViewModel);
}