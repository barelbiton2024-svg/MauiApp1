using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MauiApp1.Models;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public partial class WorkPerUserVM : ObservableObject
    {
        private readonly FirebaseAuthClient _auth;
        private readonly FirebaseClient _client;

        private string? _name;

        
        public string? _userName;

        
        public string? _email;

        
        public int _bornYear;

        
        public string? _password;

        public WorkPerUserVM(FirebaseClient client, FirebaseAuthClient auth)
        {
            _client = client;
            _auth = auth;
        }
        [RelayCommand]
        public async Task SaveWorkPerUser()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("sorry", "no internet", "ok");
                return;
            }

            await _client.Child("RegisterForWork").PostAsync(new WorkPerUser
            {

                IdUser = "13245",//_auth.User.Uid,
                Name = _name,
                Email = _email,
                UserName = _userName,
                Password = _password,
                BornYear = _bornYear,
                JobType = "hey",
                MoneyPerHour = 100,
            });

        }
    }
}
