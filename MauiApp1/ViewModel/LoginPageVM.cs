using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public partial class LoginPageVM: ObservableObject
    {
        private readonly FirebaseAuthClient _client;

        [ObservableProperty]
        public string? _email;

        [ObservableProperty]
        public string? _password;
        public LoginPageVM(FirebaseAuthClient client)
        {

        _client = client;
        }
        [RelayCommand]
        public async Task Login()
        {
            await _client.SignInWithEmailAndPasswordAsync(Email, Password);
            _ = Shell.Current.DisplayAlert("Login", $"Login succeed", "ok");
        }
    }
}