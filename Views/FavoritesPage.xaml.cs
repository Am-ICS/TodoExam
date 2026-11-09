using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoExplorer.ViewModels;

namespace TodoExplorer.Views;

public partial class FavoritesPage : ContentPage
{
    private IFavoritesPageViewModel  _favoritesViewModel;
    public FavoritesPage(IFavoritesPageViewModel 
         favoritesViewModel)
    {
        InitializeComponent();
        
        _favoritesViewModel = favoritesViewModel;
        BindingContext = favoritesViewModel;
    }

}