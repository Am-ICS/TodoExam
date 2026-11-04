using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExplorer.Models;
using TodoExplorer.ViewModels;

namespace TodoExplorer.Views;

public partial class TodoDetailsPage : ContentPage
{
    private Todo todo;
    private TodoDetailsPageViewModel _viewModel;
    public TodoDetailsPage(Todo todo)
    {
        InitializeComponent();
        BindingContext = new TodoDetailsPageViewModel(todo);
    }
}