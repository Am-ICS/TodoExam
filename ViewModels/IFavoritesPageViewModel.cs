using System.Collections.ObjectModel;
using TodoExplorer.Models;
using TodoExplorer.Services;

namespace TodoExplorer.ViewModels;

public interface IFavoritesPageViewModel

{   
    public ObservableCollection<Todo> FavTodos { get; set; }  
}