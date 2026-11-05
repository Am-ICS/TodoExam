using Moq;
using Newtonsoft.Json.Linq;
using TodoExplorer.Models;
using TodoExplorer.Services;
using TodoExplorer.ViewModels;

namespace TestTodoExplorer;

public class FavoritesPageViewModelTest
{
    [Fact]
    public async Task LoadFavoriteTodos_ShouldLoadFavorites()
    {
        // Setup
        var todo = new Todo
        {
            Id = 2

        };

        
        var MockNav = new Mock<INavigationService>();
        INavigationService nav = MockNav.Object;

        var MockfavService = new Mock<ITodoService>();
        ITodoService favService = MockfavService.Object;

        var MockFavStorage = new Mock<IFavoritesStorage>();
        IFavoritesStorage favStorage = MockFavStorage.Object;
        dynamic response = JObject.FromObject(new
        {
            todos = new List<Todo> { todo }
        });
        MockfavService
            .Setup(service => service.GetTodos())
            .ReturnsAsync((object)response);
        // Setup
                MockFavStorage.Setup(storage => storage.LoadFavorites())
                    .ReturnsAsync(new List<int> { 2 });

                var viewModel = new FavoritesPageViewModel(favStorage, favService);

        // Invoke
                await viewModel.LoadFavoriteTodos();

        // Assert
                MockFavStorage.Verify(storage => storage.LoadFavorites(), Times.Once);
                MockfavService.Verify(service => service.GetTodos(), Times.Once);
                
        
    }

    [Fact]
    public async Task SaveFavorites_ShouldBeCalledOnce()
    {
        var mockStorage = new Mock<IFavoritesStorage>();
        var storage = mockStorage.Object;
        
        var mockService = new Mock<ITodoService>();
        var favService = mockService.Object;       
        var favoristeId = new List<int> { 2, 5 };

        // Setup
        
        mockStorage.Setup(storage => storage.SaveFavorites(favoristeId))
            .Returns(Task.CompletedTask);
                
                
        // Invoke

        await storage.SaveFavorites(favoristeId);

        // Assert
        mockStorage.Verify(storage => storage.SaveFavorites(favoristeId), Times.Once);

    }
}