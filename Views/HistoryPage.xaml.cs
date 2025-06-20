using UAS.ViewModel;
using Microsoft.Maui.Controls;
using System.Globalization; // Needed for IValueConverter

namespace UAS.Views;

public partial class HistoryPage : ContentPage
{
    public HistoryPage() // Inject ViewModel
    {
        InitializeComponent();
        BindingContext = new HistoryPageViewModel(); // Set BindingContext
    }
}

// Converter to alternate row colors (simplified for example)
public class OddEvenConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string idString && idString.StartsWith("item") && int.TryParse(idString.Substring(4), out int id))
        {
            // Return true for odd IDs, false for even IDs
            return id % 2 != 0;
        }
        return false; // Default to false if not an item ID
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}