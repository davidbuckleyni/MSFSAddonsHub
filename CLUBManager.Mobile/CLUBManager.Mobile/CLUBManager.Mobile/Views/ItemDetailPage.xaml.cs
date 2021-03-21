using CLUBManager.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CLUBManager.Mobile.Views
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