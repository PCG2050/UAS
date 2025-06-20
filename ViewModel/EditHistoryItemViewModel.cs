using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UAS.Data; // Ensure you have this using statement

namespace UAS.ViewModel
{
    // Use [QueryProperty] to receive the item ID from the navigation URL
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class EditHistoryItemViewModel : ObservableObject
    {
        // Property to hold the currently edited history item
        [ObservableProperty]
        private HistoryItem _historyItem;

        // Property to receive the ItemId from the navigation query string
        [ObservableProperty]
        private string _itemId;

        public EditHistoryItemViewModel()
        {
            // Initialize HistoryItem to prevent null reference issues before data is loaded
            HistoryItem = new HistoryItem();
        }

        // This method is called automatically when ItemId is set by QueryProperty
        partial void OnItemIdChanged(string value)
        {
            // In a real application, you would fetch the HistoryItem from a database
            // or a shared service using the ItemId.
            // For this dummy example, we'll just create a dummy item for demonstration.
            // If you had a singleton data service, you'd fetch from there.

            // Simulate fetching data
            // In a real app, you might have a data service like:
            // var item = App.HistoryDataService.GetHistoryItem(value);
            // HistoryItem = item;

            // Dummy data for the edit page based on the ID
            HistoryItem = new HistoryItem
            {
                Id = value,
                Date = $"2025-06-XX ({value})",
                Time = $"10:00 AM ({value})",
                EventName = $"Edited Event for {value}",
                Location = $"New Location {value}",
                Status = "Updated",
                Notes = $"These notes were edited for {value}.",
                Category = "Re-categorized",
                Priority = "Medium"
            };
        }

        // Command to save changes and navigate back
        [RelayCommand]
        private async Task SaveChanges()
        {
            // In a real application, you would save the changes to your data source.
            // For this dummy example, we just navigate back.
            await Shell.Current.GoToAsync(".."); // Navigates back to the previous page in the shell navigation stack
        }
    }
}