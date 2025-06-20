namespace UAS.Views;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		InitializeComponent();
        BindingContext = new EntryPageViewModel();
    }
}