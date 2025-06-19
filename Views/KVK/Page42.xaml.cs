namespace UAS.Views.KVK;

public partial class Page42 : ContentPage
{
	public Page42()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var confirmResult = await DisplayAlert(
     "Confirm Submission",
     "Are you sure you want to submit this data?",
     "Yes", "No");
        if (confirmResult)
        {
            // Perform submit logic if confirmed
            bool isSuccessful = true;
            if (isSuccessful)
            {
                await DisplayAlert("Success!", "Data submitted successfully! ✔", "OK"); // Add ✔ for tick mark (limited to text)
            }
            else
            {
                // Handle error scenarios
            }
        }
        else
        {
            // User canceled - handle if needed
        }
    }
    
}