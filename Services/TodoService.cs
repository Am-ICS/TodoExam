using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using TodoExplorer.Models;

namespace TodoExplorer.Services;

public partial class 
    TodoService: ObservableObject, ITodoService
{
    private HttpClient httpClient;
    [ObservableProperty] private ObservableCollection<Todo> todos = new();

    private readonly string TODO_BASE_URL = "https://dummyjson.com/todos?";

    public TodoService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        
    }
    private async Task<dynamic> GetAsync(string url)
    {
        Uri uri = new(url);
        HttpResponseMessage response = await httpClient.GetAsync(uri);
        string responseContent = await response.Content.ReadAsStringAsync();
        dynamic json = JsonConvert.DeserializeObject(responseContent);
        return json; 

        // Uri uri = new Uri(url);
        //HttpResponseMessage response = await httpClient.GetAsync(uri);
        //string resposeContent = await response.Content.ReadAsStringAsync();
        //dynamic json = JsonConvert.DeserializeObject(resposeContent);
        //return json;

    }
    public Task<dynamic> GetTodos()
    {
        string url = TODO_BASE_URL;
        return GetAsync(url);
    }

    public Task<dynamic> GetTodosByUserId(int userId)
    {
        string url = $"{TODO_BASE_URL}/user/{userId}";
        return GetAsync(url);
    }

    public Task<dynamic> GetTodosByCompleted(bool IsCompleted)
    {
        string url = $"{TODO_BASE_URL}";
        return GetAsync(url);
    }
}