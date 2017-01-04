using laba.Models;
using laba.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace laba.ViewModels
{
    public class ProfileViewModel
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public ICommand PhotoCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ObservableCollection<ProfileModel> Profile = new ObservableCollection<ProfileModel>
        {
            new ProfileModel {Image = "https://pp.vk.me/c836720/v836720977/63ac/DQqTJei-psU.jpg"},
        };

        private Page _page;

        public ProfileViewModel(Page page)
        {
            _page = page;
            SaveCommand = new Command(OpenContacts);

        }

        private async void OpenContacts()
        {
            var dataService = DataService.GetInstance();
            var status = await dataService.ProfileAsync(FullName);
            if (status == HttpStatusCode.OK)
            {
                await _page.Navigation.PopAsync();
            }
            else
            {
                await _page.DisplayAlert("Ошибка", "Не удалось изменить имя", "Закрыть");
            }
            //Debug.WriteLine($"UserName: {FullName}, Image: {Image}");
            //await _page.Navigation.PushAsync(new ContactsPage());
        }

    }
}
