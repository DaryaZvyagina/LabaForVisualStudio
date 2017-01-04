using laba.Services;
using laba.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace laba.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private Page _page;

        public LoginViewModel(Page page)
        {
            _page = page;
            LoginCommand = new Command(OpenContacts);
            RegisterCommand = new Command(OpenRegister);
        }

        private async void OpenContacts()
        {


            var dataService = DataService.GetInstance();
            var status = await dataService.LoginAsync(UserName, Password);
            if (status == HttpStatusCode.OK)
            {
                var app = (App)Application.Current;
                app.MainPage = new NavigationPage(new ContactsPage());
            }
            else
            {
                await _page.DisplayAlert("Ошибка", "Не удалось выполнить вход", "Закрыть");
            }

        }

        private async void OpenRegister()
        {
            await _page.Navigation.PushAsync(new RegisterPage());
        }


    }
}
