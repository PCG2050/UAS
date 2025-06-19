using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace UAS.ViewModel
{
    public partial class ArticlesPageViewModel : BaseViewModel
    {
        private readonly Dictionary<string, string> _pageNameMapping;

        [ObservableProperty]
        private string _selectedPage;

        public ObservableCollection<string> PageList { get; }

        public ArticlesPageViewModel()
        {
            _pageNameMapping = new Dictionary<string, string>
            {
                { "Page1", "1. OFT" },
                { "Page2", "2. FLD" },
                { "Page3", "3. On-Campus Training Program Conducted" },
                { "Page4", "4. Off-Campus Training Programs Conducted" },
                { "Page5", "5. Lectures delivered as resources person at KVK and other departments including NGOs" },
                { "Page6", "6. Scientist visits to farmers field" },
                { "Page7", "7. Consultancy services/ Farm Advisory Services provided" },
                { "Page8", "8. Group Discussion Meetings/PRAas/Village meetings" },
                { "Page9", "9. Diagonistic field visits" },
                { "Page10", "10. News Coverage" },
                { "Page11", "11. Visitors to KVK" },
                { "Page12", "12. Film shows organised" },
                { "Page13", "13. TV/Radio programs" },
                { "Page14", "14. Exhibitions & Krishimelas organised/participated" },
                { "Page15", "15. Exposure visits/Educational Tours Organised" },
                { "Page16", "16. Field Days Organized" },
                { "Page17", "17. Celebration of Imp Events/DAys/Programs" },
                { "Page18", "18. Soil Health Camps" },
                { "Page19", "19. Animal/Human Health Camps" },
                { "Page20", "20. Method Demonstrations Conducted" },
                { "Page21", "21. Teaching Aids Developed" },
                { "Page22", "22. Farmers visit to KVK for guidance " },
                { "Page23", "23. Participation in important meetings/Trainings/Workshops/Bimonthly/Seminars/Conferences" },
                { "Page24", "24. Farmers Field Schools(FFS) Conducted" },
                { "Page25", "25. No. of farmers stayed in hostel during the month" },
                { "Page26", "26. Farm trails conducted" },
                { "Page27", "27. Soil,plant,compost & water samples tested and soil health cards distributed" },
                { "Page28", "28. Publications" },
                { "Page29", "29. Extension literature distributed or sold" },
                { "Page30", "30. Special Reports Prepared" },
                { "Page31", "31. Collaborative Programs" },
                { "Page32", "32. E-KVK Activities" },
                { "Page33", "33. Village adoption program" },
                { "Page34", "34. IFS farmers recognized" },
                { "Page35", "35. Farmer innovations/ITKs identified/recorded" },
                { "Page36", "36. Farmers recognized for organic farming" },
                { "Page37", "37. Training Hall/Conference hall rented" },
                { "Page38", "38. DAESI Program" },
                { "Page39", "39. Significant achievements" },
                { "Page40", "40. Success Story" },
                { "Page41", "41. Action taken for Scientific Advisory Commitee Recommendations" },
                { "Page42", "42. Any Other Activities not listed above" }
            };

            PageList = new ObservableCollection<string>(_pageNameMapping.Values);
        }

        partial void OnSelectedPageChanged(string value)
        {
            if (!string.IsNullOrEmpty(SelectedPage))
            {
                var pageKey = GetPageKeyFromDisplayName(SelectedPage);
                if (!string.IsNullOrEmpty(pageKey))
                {
                    NavigateToPageCommand.Execute(pageKey);
                }
            }
        }

        private string GetPageKeyFromDisplayName(string displayName)
        {
            foreach (var kvp in _pageNameMapping)
            {
                if (kvp.Value == displayName)
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        [RelayCommand]
        private async void NavigateToPage(string page)
        {
            await Shell.Current.GoToAsync(page);
        }
    }
}
