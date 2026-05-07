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
    public partial class RegisterPageVM : ObservableObject
    {
        private readonly FirebaseAuthClient _auth;
        private readonly FirebaseClient _client;
        [ObservableProperty]
        private string? _name;
       
        [ObservableProperty]
        public string? _userName;

        [ObservableProperty]
        public string? _email;

        [ObservableProperty]
        public int _bornYear;

        [ObservableProperty]
        public string? _password;

        public RegisterPageVM(FirebaseClient client,FirebaseAuthClient auth)
        { 
            _client = client;
            _auth = auth;
        }
        [RelayCommand]
        public async Task SaveRegister()
        {
            //if (connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    await Shell.Current.DisplayAlert("sorry", "no internet", "ok");
            //    return;
            //}
            await _auth.CreateUserWithEmailAndPasswordAsync(Email, Password);

            await _client.Child("RegisterUser").PostAsync(new AppUser
            {
                Id = _auth.User.Uid,
                Name = _name,
                Email = _email,
                UserName = _userName,
                Password = _password,
                BornYear = _bornYear,

            });

            }
        }
    }

