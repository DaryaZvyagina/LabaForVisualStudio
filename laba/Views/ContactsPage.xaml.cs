using laba.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace laba.Views
{
    public partial class ContactsPage : ContentPage
    {
        private readonly ContactsViewModel _viewmodel;

        public ContactsPage()
        {
            InitializeComponent();
            _viewmodel = new ContactsViewModel(this);
            BindingContext = _viewmodel;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            await _viewmodel.OpenChat();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewmodel.LoadContactsAsync();
        }
    }
}
