using MSFSAddonsHub.Forms.Models;
using MSFSAddonsHub.Forms.ViewModels;
using MSFSAddonsHub.Forms.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using MSFSAddonsHub.BL;
using MSFSAddonsHub.Dal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSFSAddonsHub.Forms.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        private MSFSAddonClient client;

        public ItemsPage()
        {
            InitializeComponent();
            client = new MSFSAddonClient();
            BindingContext = _viewModel = new ItemsViewModel();
            AuthenticateUser();
        }
        private async void AuthenticateUser() {
            List<AddonsViewModel> result = new List<AddonsViewModel>();

            await  client.AuthenticateUser(); 

            result = await client.GetAllAddons();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}