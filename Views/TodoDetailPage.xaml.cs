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
    public TodoDetailsPage(TodoDetailsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}