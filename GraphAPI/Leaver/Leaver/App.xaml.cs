using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Graph;
using Xamarin.Forms;

namespace Leaver
{
    public partial class App : Application
    {
        public static PublicClientApplication IdentityClientApp = null;
        public static string ClientID = "ca7c3371-e08c-405c-a47d-d217a4f8dedb";
        public static string[] Scopes = { "User.Read", "Calendars.Read ", "Calendars.ReadWrite" };
        public static UIParent UiParent = null;
        public static DirectoryObject Me { get; set; }
        public App()
        {
            InitializeComponent();
            IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new NavigationPage(new Leaver.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
