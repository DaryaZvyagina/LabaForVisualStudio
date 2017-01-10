using laba.Models;
using laba.Response;
using laba.Services;
using laba.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace laba.ViewModels
{
    public class ContactsViewModel
    {
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
       
        public async Task LoadContactsAsync()
        {
            var dataService = DataService.GetInstance();
            var contacts = await dataService.LoadContactsAsync();
            Contacts.Clear();

            foreach (var contact in contacts.Contacts)
            {
                contact.Image = "http://192.168.43.149:9000/" + contact.Image;
                Contacts.Add(contact);
            }


        }


        public ICommand ProfileCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public ContactsViewModel(Page page)
        {
            _page = page;
            ProfileCommand = new Command(OpenProfile);
            ExitCommand = new Command(Exit);

        }

        private Page _page;

        public async Task OpenChat()
        {
            await _page.Navigation.PushAsync(new ChatPage());
        }

        private async void OpenProfile()
        {

            await _page.Navigation.PushAsync(new ProfilePage());
        }

        private async void Exit()
        {
            var app = (App)Application.Current;
            app.MainPage = new NavigationPage(new LoginPage());

            var logout = DataService.GetInstance().LogoutAsync();
            await _page.Navigation.PopToRootAsync();

        }


    }
}
