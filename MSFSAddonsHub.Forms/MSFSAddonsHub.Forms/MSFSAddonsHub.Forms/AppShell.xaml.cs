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
            Routing.RegisterRoute(nameof(AddonsPage), typeof(AddonsPage));

            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            addonsflayout.Items.Add(new ShellContent
            {
                Title = "Airliners",
                Icon = "tab_about",
                Content = new AboutPage()
            });

            addonsflayout.Items.Add(new ShellContent
            {
                Title = "Piston Planes",
                Icon = "tab_about",
                Content = new AboutPage()
            });
            addonsflayout.Items.Add(new ShellContent
            {
                Title = "Turbo Props",
                Icon = "tab_about",
                Content = new AboutPage()
            });

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainMenu");
        }
    }
}
