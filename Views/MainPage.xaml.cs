using TodoExplorer.ViewModels;

namespace TodoExplorer.Views;

public partial class MainPage : ContentPage
{
	private IViewModelMainPage _viewModelMainPage;

	public MainPage(IViewModelMainPage viewModelMainPage)
	{
		InitializeComponent();
		_viewModelMainPage = viewModelMainPage;
		BindingContext = _viewModelMainPage;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModelMainPage.LoadTodoAsync();
	}
}
