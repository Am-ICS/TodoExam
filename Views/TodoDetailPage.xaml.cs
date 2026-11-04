using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExplorer.Models;

namespace TodoExplorer.Views;

public partial class TodoDetailPage : ContentView
{
    private Todo todo;
    public TodoDetailPage(Todo todo)
    {
        this.todo = todo;
        InitializeComponent();
    }
}