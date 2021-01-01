using MSFSAddonsHub.Forms.ViewModels;
using MSFSAddonsHub.Forms.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MSFSAddonsHub.Forms
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainMenu), typeof(MainMenu));

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainMenu");
        }
    }
}
