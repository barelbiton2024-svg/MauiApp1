using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MauiApp1.Models;
using MauiApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    //דף הוספת עבודה JobForU
    public partial class WorksVM : ObservableObject
    {
        private readonly FirebaseClient _client;

        [ObservableProperty]
        private string? _locationw;

        [ObservableProperty]
        private int _time1;

        [ObservableProperty]
        private int _moneyperhour;

        [ObservableProperty]
        private string? _jobtype;

        [ObservableProperty]
        private string? _gender;

        public WorksVM(FirebaseClient client)
        {
            _client = client;
        }
        [RelayCommand]
        public async Task SaveWorks()
        {
            try
            {
                await _client.Child("Works").PostAsync(new Works
                {
                    LocationW = _locationw,
                    Time1 = _time1,
                    MoneyPerHour = _moneyperhour,
                    JobType = _jobtype,
                    //   Gender = _gender,   

                });
            }
            catch (Exception)
            {

                _ = Shell.Current.DisplayAlert("Work", $"Add Work fail", "ok"); 
            }

        }
    }
}
