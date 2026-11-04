using Microsoft.Extensions.DependencyInjection;
using TodoExplorer.Services;
using TodoExplorer.Views;

namespace TodoExplorer;

public partial class App : Application
{
	private MainPage _mainPage;
	private readonly INavigationService  _navigationService;
	public App(MainPage mainPage, INavigationService navigationService)
	{
		InitializeComponent();
		this._mainPage = mainPage;
		_navigationService = navigationService;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		NavigationPage navigationPage = new NavigationPage(_mainPage);
		this._navigationService.SetNavigation(navigationPage.Navigation);
		return new Window(navigationPage);
	}
}