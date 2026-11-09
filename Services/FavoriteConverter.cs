using System.Globalization;

namespace TodoExplorer.Services;

public class FavoriteConverter : IValueConverter, IMarkupExtension
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool IsFavorite = (bool)value;
        if (IsFavorite)
        {
            return "❤️";
        }
        else
        {
            return "🤍";
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}