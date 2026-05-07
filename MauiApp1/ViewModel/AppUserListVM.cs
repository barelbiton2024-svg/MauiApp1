using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Database;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public partial class AppUserListVM : ObservableObject
    {
        private readonly FirebaseClient _client;
        public AppUserListVM(FirebaseClient client)
        {
            _client = client;
        }
        [ObservableProperty]
        ObservableCollection<AppUser> appuserlist = new();

        [RelayCommand]
        public async Task LoadData()
        {
            var result = _client.Child("RegisterUser").AsObservable<AppUser>().Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    item.Object.Id = item.Key;
                    appuserlist.Add(item.Object);
                }
            });
        }
        [RelayCommand]
        public async Task DeleteAppUser(string Id)
        {
            var result = await Shell.Current.DisplayAlert("Confirm", "are you sure want to delete?", "Ok", "Cancel");
            if (result)
            {
                await _client.Child($"RegisterUser/{Id}").DeleteAsync();
              //  await LoadData();
            }
        }
    }
}
