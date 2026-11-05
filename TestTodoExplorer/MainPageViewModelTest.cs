using Moq;
using TodoExplorer.Services;
using TodoExplorer.ViewModels;

namespace TestTodoExplorer;

public class MainPageViewModelTest
{
    [Fact]
    public void ToggleFilterCommand_ShouldChangeVisibility() 
    {
        //SetUp
        var mockStorage = new Mock<IFavoritesStorage>();
        var storage = mockStorage.Object;
        
        var mockService = new Mock<ITodoService>();
        var service = mockService.Object;

        var mockNav = new Mock<INavigationService>();
        var nav = mockNav.Object;
        
        var mockFavoritesVM = new Mock<IFavoritesPageViewModel>();
        var favoritesVM = mockFavoritesVM.Object;

        
        var viewModel = new ViewModelMainPage(
            storage,
            service,
            nav,
            favoritesVM
        );
        //Invoke
        viewModel.ToggleFilterCommand.Execute(null);
        //Assert
        Assert.True(viewModel.IsVisible);
        
    }
}