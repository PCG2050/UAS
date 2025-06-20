// ViewModel/HistoryPageViewModel.cs
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UAS.Data; // Ensure you have this using statement
using UAS.Views; // Ensure you have this using statement

namespace UAS.ViewModel
{
    public partial class HistoryPageViewModel : ObservableObject // Changed BaseViewModel to ObservableObject for simplicity, assuming BaseViewModel extends ObservableObject or implements INPC.
    {
        // Collection to hold your history items
        [ObservableProperty]
        private ObservableCollection<HistoryItem> _historyItems;

        public static DateTime MinFilterDate => new DateTime(2025, 1, 1);
        public static DateTime MaxFilterDate => new DateTime(2025, 12, 31);

        public HistoryPageViewModel()
        {
            HistoryItems = new ObservableCollection<HistoryItem>();
            LoadDummyData();
        }

        // Command to handle navigating to the edit page for a specific item
        [RelayCommand]
        private async Task EditHistoryItem(HistoryItem itemToEdit)
        {
            if (itemToEdit == null)
                return;

            // Navigate to the EditHistoryItemPage, passing the Id of the item
            // The query parameter name "itemId" must match the [QueryProperty] in EditHistoryItemViewModel
            await Shell.Current.GoToAsync($"{nameof(EditHistoryItemPage)}?itemId={itemToEdit.Id}");
        }

        // Dummy data loading for demonstration
        private void LoadDummyData()
        {
            for (int i = 1; i <= 20; i++) // Create 20 dummy items
            {
                HistoryItems.Add(new HistoryItem
                {
                    Id = $"item{i}",
                    Date = $"2025-06-{i:D2}",
                    Time = $"{(8 + i % 12):D2}:00 AM",
                    EventName = $"Event {i}",
                    Location = $"Location {i % 5}",
                    Status = (i % 3 == 0) ? "Completed" : "Pending",
                    Notes = $"Notes for event {i}",
                    Category = (i % 2 == 0) ? "Work" : "Personal",
                    Priority = (i % 4 == 0) ? "High" : "Low"
                });
            }
        }
    }
}