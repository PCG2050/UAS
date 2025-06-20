// Data/HistoryItem.cs
using CommunityToolkit.Mvvm.ComponentModel;

namespace UAS.Data
{
    // Use ObservableObject from CommunityToolkit.Mvvm to automatically
    // implement INotifyPropertyChanged for properties marked with [ObservableProperty].
    public partial class HistoryItem : ObservableObject
    {
        public string Id { get; set; } // Unique identifier for the item

        // Dummy data properties for 8 columns
        [ObservableProperty]
        private string _date;

        [ObservableProperty]
        private string _time;

        [ObservableProperty]
        private string _eventName;

        [ObservableProperty]
        private string _location;

        [ObservableProperty]
        private string _status;

        [ObservableProperty]
        private string _notes;

        [ObservableProperty]
        private string _category;

        [ObservableProperty]
        private string _priority;
    }
}