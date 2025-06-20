using UAS.ViewModel;
using Microsoft.Maui.Controls;

namespace UAS.Views;

public partial class EditHistoryItemPage : ContentPage
{
    public EditHistoryItemPage()
    {
        InitializeComponent();
        BindingContext = new EditHistoryItemViewModel();
    }
}