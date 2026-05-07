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
    public partial class WorksListVM : ObservableObject
    {
        private readonly FirebaseClient _client;
        [ObservableProperty]
        public static ObservableCollection<Works> workslist = new ObservableCollection<Works>();

        public WorksListVM(FirebaseClient client)
        {
            _client = client;
           // LoadData();
        }

        [RelayCommand]
        public static void ChangeList(Firebase.Database.Streaming.FirebaseEvent<Works> change)
        {
            if (change.EventType.Equals
            (Firebase.Database.Streaming.FirebaseEventType.Delete))
            {
                DeleteWorksFromList(change.Key);
            }
            if (change.EventType.Equals  (Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate))
            {
                DeleteWorksFromList(change.Key);
                if (change.Object != null)
                {
                    change.Object.Id = change.Key;
                    workslist.Add(change.Object);
                }
            }
          }

 
            public static void DeleteWorksFromList(string Id)
            {
            List<Works> new_works = new();
            foreach (Works work in workslist)
            {
                if (!work.Id.Equals(Id))
                {
                    new_works.Add(work);
                }
            }
            workslist.Clear();
            foreach (Works work in new_works)
            {
                workslist.Add(work);
            }
        }

        [RelayCommand]
        public async Task LoadData()
        {
            var result = _client.Child("Works").AsObservable<Works>().Subscribe((item) =>
            {
                if (item.Object != null)
                {
                    item.Object.Id = item.Key;
                    workslist.Add(item.Object);
                }
            });
        }


        [RelayCommand]
        public async Task DeleteWorks(string Id)
        {
            //var result = Shell.Current.DisplayAlert("Confirm", "are you sure want to delete?", "Ok", "Cancel");
            //if (result)
            {
                _client.Child($"Works/{Id}").DeleteAsync();
                //  await LoadData();
                //}
            }
        }
    }
}
