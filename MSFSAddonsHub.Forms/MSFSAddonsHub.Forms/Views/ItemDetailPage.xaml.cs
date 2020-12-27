using MSFSAddonsHub.Forms.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MSFSAddonsHub.Forms.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}