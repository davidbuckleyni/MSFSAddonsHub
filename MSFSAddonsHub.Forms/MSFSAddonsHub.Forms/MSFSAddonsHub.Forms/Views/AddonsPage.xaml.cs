using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSFSAddonsHub.BL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSFSAddonsHub.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddonsPage : ContentPage
    {
        private MSFSAddonClient _client;
        public AddonsPage()
        {
            InitializeComponent();
            _client = new MSFSAddonClient();
            BindAddons();

        }

        private async void BindAddons()
        {
            addOnList.ItemsSource = await _client.GetAllAddons();

        }

        private void RefreshView_OnRefreshing(object sender, EventArgs e)
        {
            BindAddons();
            
        }
    }
}