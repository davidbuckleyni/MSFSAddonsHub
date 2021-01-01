using MSFSAddonsHub.Forms.Services;
using MSFSAddonsHub.Forms.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MSFSAddonsHub.BL;
using MSFSAddonsHub.Dal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSFSAddonsHub.Forms
{
    public partial class App : Application
    {
         public App()
        {
            InitializeComponent();
            
      DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

     

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
