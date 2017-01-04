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
    public class RegisterViewModel
    {


        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand RegisterCommand { get; set; }

        private Page _page;

        public RegisterViewModel(Page page)
        {
            _page = page;
            RegisterCommand = new Command(OpenLogin);
        }

        private async void OpenLogin()
        {
            var dataService = DataService.GetInstance();
            var status = await dataService.RegisterAsync(FullName, UserName, Password);

            var loginStatus = await dataService.LoginAsync(UserName, Password);
            var statusProfile = await dataService.ProfileAsync(FullName);

            if (status == HttpStatusCode.OK && statusProfile == HttpStatusCode.OK && loginStatus == HttpStatusCode.OK)
            {
                var app = (App)Application.Current;
                app.MainPage = new NavigationPage(new ContactsPage());
            }
            else
            {
                await _page.DisplayAlert("Ошибка", "Не удалось зарегистрироваться", "Закрыть");
            }

            
        }


    }
}
