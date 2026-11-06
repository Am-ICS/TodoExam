using System.Net;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using TodoExplorer.Models;
using TodoExplorer.Services;
using TodoExplorer.ViewModels;

namespace TestTodoExplorer;

public class TodoServiceTest
{
    [Fact]
    public async Task Test1()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(handlerMock.Object);
        var todoService = new TodoService(httpClient);

        var todos = new List<Todo>
        {
            new Todo
            {
                Id = 1,
            }
        };
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"todos\":[],\"total\":0}")
            });
        dynamic result = await todoService.GetTodos();
        
// Assert
        Assert.NotNull(result);
        Assert.Equal(0, (int)result.total);
        Assert.Empty(result.todos);
        
    }
}