using Moq;
using Newtonsoft.Json.Linq;
using TodoExplorer.Models;
using TodoExplorer.Services;
using TodoExplorer.ViewModels;

namespace TestTodoExplorer;

public class TodoDetailsPageViewModelTests
{
    [Fact]
    public void Test1()
    {
        //SetUp
        Todo todo = new Todo
        {
            Id = 1,
            todo = "Study"
        };
        //Invoke
        var viewModel = new TodoDetailsPageViewModel();
        //Assert
        Assert.Equal(todo, viewModel.SelectedTodo);
    }
}
