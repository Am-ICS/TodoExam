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
        var todos = new Todo { id = 2 };
        var mockTodo = new Mock<ITodoService>();
        var mockStorage = new Mock<IFavoritesStorage>();
        ITodoService service = mockTodo.Object;
        IFavoritesStorage storage = mockStorage.Object;
        var mockNav = new Mock<INavigationService>();
        INavigationService nav = mockNav.Object;

        mockStorage.Setup(s => s.LoadFavorites()).ReturnsAsync(new List<int> { 2 });
        var response = new
        {
            todos = JArray.FromObject(new List<Todo> { todo })
        };

        mockTodo
            .Setup(s => s.GetTodos())
            .ReturnsAsync((dynamic)response);
        // Invoke
        var viewModel = new FavoritesPageViewModel(mockStorage, mockTodo);
        await viewModel.LoadFavoriteTodos();
        // Assert
    }
}