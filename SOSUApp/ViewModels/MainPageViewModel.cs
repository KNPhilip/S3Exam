using CommunityToolkit.Mvvm.ComponentModel;
using Entities;
using Services.Interfaces;
using System.Collections.ObjectModel;

namespace SOSUApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IResidentService<Resident> _iResidentService;

        public MainPageViewModel(IResidentService<Resident> iResidentService)
        {
            _iResidentService = iResidentService;
            Residents = new();
        }

        [ObservableProperty]
        ObservableCollection<Resident> residents;

        [ObservableProperty]
        string text;

        public async Task Initialize()
        {
            List<Resident> tempResidents = await _iResidentService.GetAllResidentsAsync();
            tempResidents.ForEach(@resident => Residents.Add(@resident));
        }
    }
}