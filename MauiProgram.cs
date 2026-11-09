using Microsoft.Extensions.Logging;
using TodoExplorer.Services;
using TodoExplorer.ViewModels;
using TodoExplorer.Views;

namespace TodoExplorer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<HttpClient>();
		
		builder.Services.AddSingleton<INavigationService, NavigationService>();
		
		builder.Services.AddSingleton<IFavoritesStorage>(_ =>
			new JsonFavoritesStorage(FileSystem.AppDataDirectory, "favorites.json")
		);
		
		builder.Services.AddSingleton<ITodoService, TodoService>();
		
		
		builder.Services.AddTransient<IViewModelMainPage,  ViewModelMainPage>();
		builder.Services.AddTransient <MainPage>();
		builder.Services.AddTransient<IFavoritesPageViewModel, FavoritesPageViewModel>();
		builder.Services.AddTransient<FavoritesPage>();
		builder.Services.AddTransient<TodoDetailsPageViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
