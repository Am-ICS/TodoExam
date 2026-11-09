using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoExplorer.Models;
using TodoExplorer.Services;


namespace TodoExplorer.ViewModels;

public partial class TodoDetailsPageViewModel: ObservableObject
{
    [ObservableProperty]
    
    private Todo? selectedTodo;
    
    
    private readonly INavigationService _navigationService;

    public TodoDetailsPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    [RelayCommand]
    public async Task GoBackToMainPage()
    {
        await this._navigationService.PopAsync();
    }
}